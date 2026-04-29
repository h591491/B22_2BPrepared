using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timer = 0f;
    public string lastCheckpoint = "intro_animation";
    public bool timerRunning = false;

    public List<GameAction> actions = new List<GameAction>();

    public string lastScene;
    public string currentScene;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            timer += Time.deltaTime;
        }

    }

    public void Restart()
    {
        timer = 0f;
        lastCheckpoint = "intro_animation";
        timerRunning = false;

        foreach(var a in actions){
            a.done = false;
            a.penalty = 0;
        }
        lastScene = "";
     }


    public void SaveCheckpoint()
    {
        lastCheckpoint = SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string scenename)
    {
        lastScene = SceneManager.GetActiveScene().name;
        currentScene = scenename;
        SceneManager.LoadScene(scenename);
    }

    public void LoadLastScene()
    {
        currentScene = lastScene;
        SceneManager.LoadScene(lastScene);
    }

    public void SpescialSceneLoad()
    {
        switch (currentScene)
        {
            case "4b_emergency_call":
                if(lastScene == "4a_Notify")
                {
                    LoadScene("New Scene");
                }
                else
                {
                    LoadLastScene();
                }
                break;
            case "first_summary":
                if (GameManager.Instance.CheckObjectState("tlf"))
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




    public bool CheckObjectState(string id)
    {
        GameAction ga = actions.Find(a => a.id == id);
        return ga != null && ga.done;
    }

    public void CompleteAction(string id)
    {
        var a = actions.Find(a => a.id == id);

        if(a == null)
        {
            return;
        }

        a.done = true;
    }

    public int GetScore()
    {
        int score = 0;

        foreach (GameAction action in actions)
        {
            if(action.done){
                score += action.points + action.penalty;
            }
        }
        return score;
    }

    public int GetMaxScore()
    {
        return actions.Where(a => a.points > 0).Sum(a => a.points);
    }

}
