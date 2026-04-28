using UnityEngine;

[System.Serializable]
public class GameAction
{
    public string id;
    public bool done;
    public string doneText;
    public string notDoneText;
    public int points;
    public int penalty;

    public string GetFeedback()
    {
        return done ? doneText : notDoneText;
    }

    

    
}
