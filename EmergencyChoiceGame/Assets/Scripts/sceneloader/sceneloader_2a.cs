using UnityEngine;

public class sceneloader_2a : MonoBehaviour
{
    public MouseHover[] objects;

    private CheckpointManager chmanager;
    private GameState state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chmanager = GameRoot.Instance.GetComponent<CheckpointManager>();
        state = GameRoot.Instance.GetComponent<GameState>();

        // For testing
        chmanager.SaveCheckpoint();

        foreach (var obj in objects)
        {
            bool hide = false;

            // Sjekk state
            if (obj.objectID != "tlf" && state.CheckObjectState(obj.objectID))
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
}
