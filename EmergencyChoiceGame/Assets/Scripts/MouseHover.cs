using System.Linq;
using TMPro;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    Vector3 originalScale;
    public float scaleMultiplier = 1.4f;

    public string text;
    public TMP_Text hoverText;

    public bool loadSceneOnClick = false;
    public bool loadDialogueBox = false;
    public string nextScene;

    public string objectID;

    public sceneloader_2b sceneLoader;

    private bool active;
    private SceneController sceneController;
    private GameState state;


    void Start()
    {
        sceneController = GameRoot.Instance.GetComponent<SceneController>();
        state = GameRoot.Instance.GetComponent<GameState>();

        originalScale = transform.localScale;
        hoverText.gameObject.SetActive(false);

        active = true;
    }

    void OnMouseEnter()
    {
        if (!active)
        {
            return;
        }

        hoverText.text = text;
        transform.localScale = originalScale * scaleMultiplier;
        hoverText.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        if (!active)
        {
            return;
        }

        transform.localScale = originalScale;
        hoverText.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!active)
        {
            return;
        }

        CheckId();

        if (loadDialogueBox)
        {
            gameObject.SetActive(false);
            hoverText.gameObject.SetActive(false);
            sceneLoader.ShowDialogueBox(nextScene);
        }
        if (loadSceneOnClick)
        {
            sceneController.LoadScene(nextScene);
        }
        else
        {
            gameObject.SetActive(false);
            hoverText.gameObject.SetActive(false);
        }       
    }

    private void CheckId()
    {
        if (string.IsNullOrEmpty(objectID))
        {
            return;
        }
        state.CompleteAction(objectID);
    }

    public void SetActive(bool b)
    {
        active = b;

        if (!b)
        {
            transform.localScale = originalScale;
            hoverText.gameObject.SetActive(false);
        }
    }
}