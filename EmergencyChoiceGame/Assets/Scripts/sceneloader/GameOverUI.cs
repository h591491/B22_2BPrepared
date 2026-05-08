using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI reasonText;
    private GameState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameRoot.Instance.GetComponent<GameState>();

        timerText.text = "Time: " + state.timer.ToString("F1") + " sec";
        scoreText.text = "Score: " + state.GetScore().ToString() + "/" + state.GetMaxScore().ToString();
        reasonText.text = state.gameOverReason;
    }

    
}
