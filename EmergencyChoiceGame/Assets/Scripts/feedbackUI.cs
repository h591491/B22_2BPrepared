using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class feedbackUI : MonoBehaviour
{
    public GameObject feedbackCanvas;
    public TMP_Text txtFeedback;

    private string nextScene;
    private SceneController sceneController;
    private GameState state;

    public List<SceneFeedback> sceneFeedbacks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneController = GameRoot.Instance.GetComponent<SceneController>();
        if (sceneController == null)
        {
            Debug.LogError("SceneController missing!");
            enabled = false;
            return;
        }
        state = GameRoot.Instance.GetComponent<GameState>();
        if (state == null)
        {
            Debug.LogError("SceneController missing!");
            enabled = false;
            return;
        }

        feedbackCanvas.SetActive(false);
    }

    public void setNextScene(string nextScene)
    {
        this.nextScene = nextScene;
    }

    // Update is called once per frame
    public void ShowFeedback(string feedback)
    {
        txtFeedback.text = feedback;

        Canvas[] canvases = Object.FindObjectsByType<Canvas>(FindObjectsSortMode.None);

        foreach (Canvas c in canvases)
        {
            if (c.gameObject != feedbackCanvas)
            {
                c.gameObject.SetActive(false);
            }
        }
        feedbackCanvas.SetActive(true);
    }
    public void ShowDetailedFeedback()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneFeedback sf = sceneFeedbacks.Find(s => s.sceneName == sceneName);

        if (sf == null)
        {
            Debug.LogError($"No sceneFeedback found for scene: {sceneName}");
            return;
        }

        ShowFeedback(getDetailedFeedback(sf));
    }

    public void HideFeedback()
    {
        Canvas[] canvases = Object.FindObjectsByType<Canvas>(FindObjectsSortMode.None);

        foreach (Canvas c in canvases)
        {
            if (c.gameObject != feedbackCanvas)
            {
                c.gameObject.SetActive(true);
            }
        }

        txtFeedback.text = "";
        feedbackCanvas.SetActive(false);
        sceneController.LoadScene(nextScene);
    }

    public string getDetailedFeedback(SceneFeedback sf)
    {
        bool good = sf.goodRequiredActions.All(id => state.CheckObjectState(id));
        bool medium = sf.mediumRequiredActions.All(id => state.CheckObjectState(id));

        string text = "";

        if (good)
        {
            text += sf.goodText;
            if (medium) text += sf.mediumText;
        }
        else
        {
            text += sf.badText;
            if (medium) text += sf.mediumText;
        }

        return text;
    }

}
