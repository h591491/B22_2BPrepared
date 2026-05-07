using UnityEngine;

public class FollowupController : MonoBehaviour
{
    public string returnScene;

    private SceneController sceneController;
    private GameState state;

    void Start()
    {
        EnsureRefs();
    }

    void EnsureRefs()
    {
        if (sceneController == null)
            sceneController = GameRoot.Instance.GetComponent<SceneController>();
        if (state == null)
            state = GameRoot.Instance.GetComponent<GameState>();
    }

    public void ShowPanel(GameObject panelToShow)
    {
        Transform parent = panelToShow.transform.parent;
        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(false);
        }
        panelToShow.SetActive(true);
    }

    public void Answer(string actionID, int pointModifier)
    {
        EnsureRefs();
        var action = state.actions.Find(a => a.id == actionID);
        if (action == null)
        {
            Debug.LogWarning($"[FollowupController] Action '{actionID}' not found in GameState.");
            return;
        }
        action.done = true;
        action.additionalPoints = pointModifier;
    }

    public void ReturnToTriage()
    {
        EnsureRefs();
        sceneController.LoadScene(returnScene);
    }
}