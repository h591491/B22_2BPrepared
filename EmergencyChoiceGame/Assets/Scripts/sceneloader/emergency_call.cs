using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class emergency_call : MonoBehaviour
{
    private int count;
    private int point;
    private int totPoint;
    private int opt;
    private Question[] questions;

    public TMP_Text txtQ;
    public TMP_Text txtA;
    public TMP_Text txtTotPoints;
    public TMP_Text txtPoints;
    public Button btnReturn;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
        totPoint = 0;
        point = 0;
        opt = 0;
        btnReturn.gameObject.SetActive(false);
        //string lastScene = GameManager.Instance.lastScene;


        questions = new Question[]
        {
            new Question
            {
                questionText = "Emergency services. What is your emergency?",
                options = new Option[]
                {
                    new Option { text = "There has been a car accident", score = 2 },
                    new Option { text = "Someone is hurt", score = -2 },
                    new Option { text = "I need help", score = 0 }
                }
            },
            new Question
            {
                questionText = "What is your exact location?",
                options = new Option[]
                {
                    new Option { text = "I don't know", score = 0 },
                    new Option { text = "I'm on road 97, Fjord", score = -2 },
                    new Option { text = "I'm on road 116, Fjell", score = 2 }
                }
            },
            new Question
            {
                questionText = "Tell me exactly what has happened.",
                options = new Option[]
                {
                    new Option { text = "Two cars crashed", score = -2 },
                    new Option { text = "A car drove off the road", score = 2 },
                    new Option { text = "I'm not sure", score = 0 }
                }
            },
            new Question
            {
                questionText = "Can you give me your name and the number you're calling from?",
                options = new Option[]
                {
                    new Option { text = "Yes, it's Kim, 12345678", score = 2 },
                    new Option { text = "My name is Kim", score = 0 },
                    new Option { text = "I don't want to say", score = -2 }
                }
            },
            new Question
            {
                questionText = "Are there any injured?",
                options = new Option[]
                {
                    new Option { text = "Yes", score = 0 },
                    new Option { text = "No", score = 0 },
                    new Option { text = "I don't know", score = 0 }
                }
            },
            new Question
            {
                questionText = "How many people are hurt?",
                options = new Option[]
                {
                    new Option { text = "I don't know", score = -2 },
                    new Option { text = "2", score = 0 },
                    new Option { text = "4", score = 2 }
                }
            }
            ,
            new Question
            {
                questionText = "Alright, stay on the line. Help is on the way.",
                options = null
            }
        };

        ShowText();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void ShowText()
    {
        if(questions[count].options == null)
        {
            btnReturn.gameObject.SetActive(true);
        }
        
        txtQ.text = questions[count].questionText;
        txtA.text = "";


    }

    public void ShowOption(int opt)
    {
        if (questions[count].options == null)
        {
            return;
        }

        txtA.text = questions[count].options[opt - 1].text;
        this.opt = opt;
    }


    public void Next()
    {
        if(opt == 0)
        {
            return;
        }

        point = questions[count].options[opt - 1].score;
        totPoint += point;
        count++;
        ShowText();

        txtTotPoints.text = $"Points: {totPoint}";
        if(point > 0) txtPoints.text = $"+{point}";
        else txtPoints.text = point.ToString();
        opt = 0;
    }

    public void Return()
    {
        GameAction a = GameManager.Instance.actions.Find(a => a.id == "tlf");
        a.penalty += totPoint;
    }


}
