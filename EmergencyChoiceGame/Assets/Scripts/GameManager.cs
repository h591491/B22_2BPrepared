using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timer = 0f;
    public string lastSavedScene = "intro_animation";
    public bool timerRunning = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
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

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    
}
