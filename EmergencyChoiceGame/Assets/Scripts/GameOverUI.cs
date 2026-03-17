using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void LoadCheckpointScene()
    {
        string lastSavedScene = GameManager.Instance.lastSavedScene;
        SceneManager.LoadScene(lastSavedScene);
    }

    public void LoadStartScene()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("intro_animation");
    }

}
