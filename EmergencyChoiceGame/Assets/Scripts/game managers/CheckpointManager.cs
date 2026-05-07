using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    public Checkpoint lastCheckpoint;
    
    private GameState state;
    private SceneController scene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        state = GetComponent<GameState>();
        scene = GetComponent<SceneController>();

        if (state == null)
        {
            Debug.LogError("GameState missing!");
        }
        if (scene == null)
        {
            Debug.LogError("SceneController missing!");
        }

        SaveFirstCheckpoint();
    }

    // Update is called once per frame
    
    public void SaveFirstCheckpoint()
    {
        lastCheckpoint = new Checkpoint() { sceneName = "intro_animation" };
        lastCheckpoint.actions = state.actions.Select(a => a.clone()).ToList();
    }
    public void SaveCheckpoint()
    {
        lastCheckpoint.sceneName = SceneManager.GetActiveScene().name;
        lastCheckpoint.actions = state.actions.Select(a => a.clone()).ToList();
    }

    public void LoadCheckpoint()
    {
        state.actions = lastCheckpoint.actions.Select(a => a.clone()).ToList();
        state.timerRunning = true;
        scene.LoadSceneWithoutHistory(lastCheckpoint.sceneName);
    }
}
