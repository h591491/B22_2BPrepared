using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timer = 0f;
    public string lastSavedScene = "intro_animation";
    public bool timerRunning = false;

    public List<GameAction> actions = new List<GameAction>();

    // scene: 2b_bringFromCar states:
    public HashSet<string> collectedObjects = new HashSet<string>();


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



    // scene: 2b_bringFromCar and triangle minigame
    public void SetObjectCollected(string id)
    {
        collectedObjects.Add(id);
    }

    // scene: 2b_bringFromCar and triangle minigame
    public bool IsObjectCollected(string id)
    {
        return collectedObjects.Contains(id);
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
                score += action.points;
            }
        }
        return score;
    }

    public int GetMaxScore()
    {
        return actions.Where(a => a.points > 0).Sum(a => a.points);
    }

}
