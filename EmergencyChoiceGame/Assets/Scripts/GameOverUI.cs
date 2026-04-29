using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float finalTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finalTime = GameManager.Instance.finaltime;
        timerText.text = "Time: " + finalTime.ToString("F2") + " seconds";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
