using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class feedback : MonoBehaviour
{
    private string youDidText = "";
    private string youDidNotText = "";
    private string summary = "";

    public TMP_Text summaryTextBox;

    public string nextscene = "";
    public string nextsceneElse = "";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(GameAction action in GameManager.Instance.actions)
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
        int score = GameManager.Instance.GetScore();
        int maxScore = GameManager.Instance.GetMaxScore();

        return
        $"<size=120%><b>What you did:</b></size>\n" +
        $"{youDidText}\n" +
        $"<size=120%><b>What you missed:</b></size>\n" +
        $"{youDidNotText}\n" + 
        $"<size=120%><b>Score: {score} / {maxScore}</b></size>";
    }

    public void OnContinuePressed()
    {
        if (GameManager.Instance.CheckObjectState("tlf"))
        {
            GameManager.Instance.LoadScene(nextsceneElse);
        }
        else
        {
            GameManager.Instance.LoadScene(nextscene);
        }
    }
}
