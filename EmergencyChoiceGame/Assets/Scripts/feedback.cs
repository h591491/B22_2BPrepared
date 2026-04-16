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

    // When it is done
    private Dictionary<string, string> feedbackDone = new Dictionary<string, string>()
    {
        { "tlf", "You called emergency services" },
        { "vest", "You put on a high-visibility vest"},
        { "hazardLight", "You turned on the hazard lights"},
        { "triangle", "You placed the warning triangle" }
    };

    // When it is not done
    private Dictionary<string, string> feedbackNotDone = new Dictionary<string, string>()
    {
        { "tlf", "You did not call emergency services" },
        { "vest", "You did not put on a high-visibility vest" },
        { "hazardLight", "You did not turn on the hazard lights" },
        { "triangle", "You did not place a warning triangle" }
    };


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(string id in GameManager.Instance.objectStates.Keys)
        {
            
            if (GameManager.Instance.ChechObjectState(id))
            {
                youDidText += GetFeedback(id, true);
                if (id.Equals("triangle"))
                {
                    youDidText += GetPlacementText();
                }

                youDidText += "\n";
            }
            else
            {
                youDidNotText += GetFeedback(id, false) + "\n";
            }

        }

        summary = WriteSummary();
        
        summaryTextBox.text = summary;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetFeedback(string id, bool done)
    {
        var dict = done ? feedbackDone : feedbackNotDone;

        if (dict.TryGetValue(id, out string text))
            return text;

        return "";
    }

    public string WriteSummary()
    {
        return
        $"<size=120%><b>What you did:</b></size>\n" +
        $"{youDidText}\n\n" +
        $"<size=120%><b>What you missed:</b></size>\n" +
        $"{youDidNotText}";
    }

    public void OnContinuePressed()
    {
        if (GameManager.Instance.ChechObjectState("tlf"))
        {
            GameManager.Instance.LoadScene(nextsceneElse);
        }
        else
        {
            GameManager.Instance.LoadScene(nextscene);
        }
    }

    public string GetPlacementText()
    {
        switch (GameManager.Instance.triangleplacement)
        {
            case 1:
                return ", and it was placed correctly";
            case 2:
                return ", but the placement was slightly off";
            case 3:
                return ", and the placement was incorrect";
            default:
                return "";

        }
    }

}
