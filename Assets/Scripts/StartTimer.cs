using UnityEngine;

public class StartTimer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
