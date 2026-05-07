using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string lastScene;
    public string currentScene;

    private GameState state;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        state = GetComponent<GameState>();
        if (state == null)
        {
            Debug.LogError("GameState missing!");
        }
    }

    // Update is called once per frame
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }
    public void LoadScene(string scenename)
    {
        lastScene = SceneManager.GetActiveScene().name;
        currentScene = scenename;
        SceneManager.LoadScene(scenename);
    }
    public void LoadSceneWithoutHistory(string scenename)
    {
        currentScene = scenename;
        SceneManager.LoadScene(scenename);
    }

    public void LoadLastScene()
    {
        currentScene = lastScene;
        SceneManager.LoadScene(lastScene);
    }


    public string SpecialSceneSet(bool requirement)
    {
        switch (currentScene)
        {
            case "3A":
                if (requirement)
                {
                    return "4a_Notify";
                }
                else
                {
                    return Scenes.GameOver;
                }
        }

        return "";
    }

    public void SpecialSceneLoad()
    {
        switch (currentScene)
        {
            case "4b_emergency_call":
                if (lastScene == "4a_Notify")
                {
                    LoadScene("New Scene");
                }
                else
                {
                    LoadLastScene();
                }
                break; 
            case "first_summary":
                if (lastScene == "gameover")
                {
                    LoadScene("gameover");
                    break;
                }
                if (state.CheckObjectState("tlf"))
                {
                    LoadScene("New Scene");
                }
                else
                {
                    LoadScene("4a_Notify");
                }
                break;


        }


    }
}
