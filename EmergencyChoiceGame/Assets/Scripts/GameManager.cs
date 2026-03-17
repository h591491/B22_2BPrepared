using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timer = 0f;
    public string lastSavedScene = "intro_animation";
    public bool timerRunning = false;

    public bool stoppedNearby = false;
    public bool stoppedFurtherAway = false;

    public bool harRefleksvest = false;
    public bool harNodblink = false;
    public bool harHandbrekk = false;
    public bool harVarsletNodetat = false;

    public int danger = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (timerRunning)
        {
            timer += Time.deltaTime;
        }
    }

    public void SaveCheckpoint()
    {
        lastSavedScene = SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResetGame()
    {
        timer = 0f;
        timerRunning = false;
        lastSavedScene = "intro_animation";

        stoppedNearby = false;
        stoppedFurtherAway = false;

        harRefleksvest = false;
        harNodblink = false;
        harHandbrekk = false;
        harVarsletNodetat = false;

        danger = 0;
    }
}