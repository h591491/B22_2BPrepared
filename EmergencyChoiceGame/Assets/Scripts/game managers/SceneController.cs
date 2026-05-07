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
                    return "TriageFront";
                }
                else
                {
                    return Scenes.GameOver;
                }
        }

        return "";
    }
}
