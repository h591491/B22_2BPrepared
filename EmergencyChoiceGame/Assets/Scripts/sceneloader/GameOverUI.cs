using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText.text = "Time: " + GameManager.Instance.timer.ToString("F1") + " seconds";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
