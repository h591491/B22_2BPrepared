using System;
using UnityEngine;

[System.Serializable]
public class GameAction
{
    public string id;
    public bool done;
    public string doneText;
    public string notDoneText;
    public int points;
    public int additionalPoints;

    public string GetFeedback()
    {
        return done ? doneText : notDoneText;
    }

    public GameAction clone()
    {
        return new GameAction
        {
            id = this.id,
            done = this.done,
            doneText = this.doneText,
            notDoneText = this.notDoneText,
            points = this.points, 
            additionalPoints = this.additionalPoints
        };

    }

    

    
}
