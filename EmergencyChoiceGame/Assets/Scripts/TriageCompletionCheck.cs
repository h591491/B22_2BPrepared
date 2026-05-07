using UnityEngine;

public class TriageCompletionCheck : MonoBehaviour
{
    public string[] passengerActionIDs;

    public string nextScene;

    private GameState state;
    private SceneController sceneController;

    void Start()
    {
        state = GameRoot.Instance.GetComponent<GameState>();
        sceneController = GameRoot.Instance.GetComponent<SceneController>();

        if (AllDone())
        {
            sceneController.LoadScene(nextScene);
        }
    }

    bool AllDone()
    {
        foreach (var id in passengerActionIDs)
        {
            if (!state.CheckObjectState(id))
            {
                return false;
            }
        }
        return true;
    }
}