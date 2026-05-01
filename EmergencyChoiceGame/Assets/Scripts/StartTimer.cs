using UnityEngine;

public class StartTimer : MonoBehaviour
{
    private GameState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameRoot.Instance.GetComponent<GameState>();
        state.timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
