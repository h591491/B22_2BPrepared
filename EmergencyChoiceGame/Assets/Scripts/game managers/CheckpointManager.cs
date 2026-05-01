using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    public Checkpoint lastCheckpoint = new Checkpoint() { sceneName = "intro_animation" };
    
    private GameState state;
    private SceneController scene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        state = GetComponent<GameState>();
        scene = GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
