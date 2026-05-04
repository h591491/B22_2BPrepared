using UnityEngine;
using UnityEngine.UI;

public class PassengerButton : MonoBehaviour
{
    public string objectID;

    public string nextScene;

    private GameState state;
    private SceneController sceneController;
    private UIHoverText hoverText;

    void Start()
    {
        state = GameRoot.Instance.GetComponent<GameState>();
        sceneController = GameRoot.Instance.GetComponent<SceneController>();
        hoverText = GetComponent<UIHoverText>();

        // If this passenger has already been treated, hide the whole button
        if (state.CheckObjectState(objectID))
        {
            gameObject.SetActive(false);
            return;
        }

        // Hook up the click
        GetComponent<Button>().onClick.AddListener(OnClicked);
    }

    void OnClicked()
    {
        // Mark as treated
        state.CompleteAction(objectID);

        // Hide hover text immediately so it doesn't linger
        if (hoverText != null && hoverText.hoverText != null)
        {
            hoverText.hoverText.gameObject.SetActive(false);
        }

        // Load the passenger's follow-up scene
        sceneController.LoadScene(nextScene);
    }
}