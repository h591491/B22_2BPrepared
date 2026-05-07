using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public string actionID;

    public int pointModifier;

    public FollowupController followup;

    public bool returnToTriageOnClick = true;

    public GameObject nextPanel;

    private GameState state;

    void Start()
    {
        state = GameRoot.Instance.GetComponent<GameState>();
        GetComponent<Button>().onClick.AddListener(OnClicked);
    }

    void OnClicked()
    {
        var action = state.actions.Find(a => a.id == actionID);
        if (action != null)
        {
            action.done = true;
            action.additionalPoints = pointModifier;
        }
        else
        {
            Debug.LogWarning($"[AnswerButton] Action '{actionID}' not found in GameState.");
        }

        if (returnToTriageOnClick)
        {
            followup.ReturnToTriage();
        }
        else
        {
            followup.ShowPanel(nextPanel);
        }
    }
}