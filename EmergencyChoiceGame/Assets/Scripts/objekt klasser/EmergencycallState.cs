using System.Threading;
using UnityEngine;

public class EmergencycallState
{
    public int count;
    public int totPoint;
    public Question[] questions;


    public EmergencycallState()
    {
        SetStartValues();
    }

    public void SetStartValues()
    {
        count = 0;
        totPoint = 0;


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
    }
}
