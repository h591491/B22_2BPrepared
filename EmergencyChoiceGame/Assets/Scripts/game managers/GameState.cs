using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public float timer = 0f;
    public bool timerRunning = false;
    public List<GameAction> actions = new List<GameAction>();
    public string gameOverReason;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (actions == null)
        {
            actions = new List<GameAction>();
            Debug.LogWarning("Actions list is null");
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

    public void CompleteAction(string id)
    {
        var a = actions.Find(a => a.id == id);

        if (a != null)
        {
            a.done = true;
        }
        else{
            Debug.LogWarning($"Action with id: {id} not found.");
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
                score += action.points + action.additionalPoints;
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
            a.additionalPoints = 0;
        }
    }
}
