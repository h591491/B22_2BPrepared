using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public float timer = 0f;
    public bool timerRunning = false;
    public List<GameAction> actions = new List<GameAction>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            timer += Time.deltaTime;
        }
    }

    public void CompleteAction(string id)
    {
        var a = actions.Find(a => a.id == id);

        if (a != null)
        {
            a.done = true;
        }
    }

    public bool CheckObjectState(string id)
    {
        GameAction ga = actions.Find(a => a.id == id);
        return ga != null && ga.done;
    }

    public int GetScore()
    {
        int score = 0;

        foreach (GameAction action in actions)
        {
            if (action.done)
            {
                score += action.points + action.penalty;
            }
        }
        return score;
    }

    public int GetMaxScore()
    {
        return actions.Where(a => a.points > 0).Sum(a => a.points);
    }

    public void ResetGameState()
    {
        timer = 0f;
        timerRunning = false;

        foreach (var a in actions)
        {
            a.done = false;
            a.penalty = 0;
        }
    }
}
