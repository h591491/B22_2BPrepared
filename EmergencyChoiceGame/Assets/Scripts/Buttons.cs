using UnityEngine;

public class Buttons : MonoBehaviour
{
    private SceneController sceneController;
    private CheckpointManager chmanager;
    private feedbackUI feedbackUI;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneController = GameRoot.Instance.GetComponent<SceneController>();
        chmanager = GameRoot.Instance.GetComponent<CheckpointManager>();
        feedbackUI = GameRoot.Instance.GetComponent<feedbackUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        sceneController.Restart();
    }

    public void Gameover()
    {
        sceneController.GameOver();
    }
    public void GoToMainMenu()
    {
        sceneController.GoToMainMenu();
    }

    public void StartFromCheckpoint()
    {
        chmanager.LoadCheckpoint();
    }

    public void LoadScene(string sceneName)
    {
        sceneController.LoadScene(sceneName);
    }

    public void LoadLastScene()
    {
        sceneController.LoadLastScene();
    }

    public void SpecialSceneLoad()
    {
        sceneController.SpecialSceneLoad();
    }

    public void setNextScene(string nextScene)
    {
        feedbackUI.setNextScene(nextScene);
    }

    public void showFeedback(string feedbackText)
    {
        feedbackUI.ShowFeedback(feedbackText);
    }

    public void showDetailedFeedback()
    {
        feedbackUI.ShowDetailedFeedback();
    }

}
