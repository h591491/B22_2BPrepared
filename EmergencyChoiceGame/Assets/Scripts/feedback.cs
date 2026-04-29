using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class feedback : MonoBehaviour
{
    private string youDidText = "";
    private string youDidNotText = "";
    private string summary = "";
    private string youDidHeader = "<size=120%><b>What you did:</b></size>\n";
    private string youDidNotHeader = "<size=120%><b>What you missed:</b></size>\n";

    public TMP_Text summaryTextBox;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        foreach (GameAction action in GameManager.Instance.actions)
        {
            
            if (action.done && action.doneText != "") 
            {
                youDidText += action.doneText + "\n";
            }
            else
            {
                if (action.notDoneText != "")
                {
                    youDidNotText += action.notDoneText + "\n";
                }
            }

        }

        summary = WriteSummary();
        summaryTextBox.text = summary;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    public string WriteSummary()
    {
        string scoretext = WriteScore();
        
        if(youDidText == "")
        {
            return youDidNotHeader + youDidNotText + scoretext;
        }
        else if(youDidNotText == "")
        {
            return youDidHeader + youDidText + scoretext;
        }
        else
        {
            return youDidHeader + youDidText + "\n" + youDidNotHeader + youDidNotText + scoretext;
        }
    }

    public string WriteScore()
    {
        int score = GameManager.Instance.GetScore();
        int maxScore = GameManager.Instance.GetMaxScore();
        return $"\n<size=120%><b>Score: {score} / {maxScore}</b></size>";
    }
}
