using UnityEngine;

public class sceneloader_2b : MonoBehaviour
{
    public GameObject task;
    public GameObject dialogue;
    public MouseHover[] objects;

    private string nextScene;

    private SceneController sceneController;
    private GameState state;
    private CheckpointManager chmanager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneController = GameRoot.Instance.GetComponent<SceneController>();
        state = GameRoot.Instance.GetComponent<GameState>();
        chmanager = GameRoot.Instance.GetComponent<CheckpointManager>();

        chmanager.SaveCheckpoint();

        dialogue.SetActive(false);
        task.SetActive(true);

        foreach (var obj in objects)
        {
            bool hide = false;

            // Sjekk state
            if (obj.objectID != "tlf" && state.CheckObjectState(obj.objectID))
            {
                hide = true;
            }

            if (obj.objectID == "triangle" && state.triangleTries <= 0)
            {
                hide = true;
            }

            obj.gameObject.SetActive(!hide);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDialogueBox(string nextScene)
    {
        SetMouseHoverActive(false);

        this.nextScene = nextScene;
        task.SetActive(false);
        dialogue.SetActive(true);
    }

    public void HideDialogueBox()
    {
        // Velger å ikke plassere trekanten nå:
        var ta = state.actions.Find(a => a.id == "triangle");
        ta.done = false;
        
        SetMouseHoverActive(true);
        dialogue.SetActive(false);
        task.SetActive(true);
    }

    public void placeTriangleNow()
    {
        sceneController.LoadScene(nextScene);
    }

    public void SetMouseHoverActive(bool state)
    {
        foreach (var obj in objects)
        {
            obj.SetActive(state);
        }
    }
}
