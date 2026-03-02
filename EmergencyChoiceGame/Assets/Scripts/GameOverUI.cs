using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float finalTime = GameManager.Instance.timer;
        timerText.text = "Time: " + finalTime.ToString("F2") + " seconds";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
