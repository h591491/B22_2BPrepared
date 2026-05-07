using UnityEngine;

public class Buttons : MonoBehaviour
{
    private SceneController sceneController;
    private CheckpointManager chmanager;
    private feedbackUI feedbackUI;
    private GameState state;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneController = GameRoot.Instance.GetComponent<SceneController>();
        chmanager = GameRoot.Instance.GetComponent<CheckpointManager>();
        feedbackUI = GameRoot.Instance.GetComponent<feedbackUI>();
        state = GameRoot.Instance.GetComponent<GameState>();
    }

    public void Restart()
    {
        state.ResetGameState();
        sceneController.LoadScene(Scenes.Intro);
    }

    public void Gameover() 
    {
        state.timerRunning = false;
        sceneController.LoadScene(Scenes.GameOver);
    }
    public void SetGameOverReason(string reason)
    {
        state.gameOverReason = reason;
    }
    public void GoToMainMenu()
    {
        state.ResetGameState();
        sceneController.LoadScene(Scenes.MainMenu);
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

    public void SpecialSceneSet(string requiredAction) 
    {
        bool requirement = state.CheckObjectState(requiredAction);

        string nextScene = sceneController.SpecialSceneSet(requirement);
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
