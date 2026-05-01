using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private GameState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameRoot.Instance.GetComponent<GameState>();

        timerText.text = "Time: " + state.timer.ToString("F1") + " seconds";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
