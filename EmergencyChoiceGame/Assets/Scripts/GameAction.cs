using UnityEngine;

[System.Serializable]
public class GameAction
{
    public string id;
    public bool done;
    public string doneText;
    public string notDoneText;
    public int points;

    public string GetFeedback()
    {
        return done ? doneText : notDoneText;
    }

    

    
}
