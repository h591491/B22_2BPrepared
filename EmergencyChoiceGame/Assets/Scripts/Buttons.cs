using UnityEngine;

public class Buttons : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        GameManager.Instance.Restart();
    }

    public void Gameover()
    {
        GameManager.Instance.GameOver();
    }
    public void GoToMainMenu()
    {
        GameManager.Instance.GoToMainMenu();
    }

    public void StartFromCheckpoint()
    {
        GameManager.Instance.LoadCheckpoint();
    }

    public void LoadScene(string sceneName)
    {
        GameManager.Instance.LoadScene(sceneName);
    }

    public void LoadLastScene()
    {
        GameManager.Instance.LoadLastScene();
    }

    public void SpescialSceneLoad()
    {
        GameManager.Instance.SpescialSceneLoad();
    }
}
