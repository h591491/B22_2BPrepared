using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class emergency_call : MonoBehaviour
{
    private int point;
    private int opt;
    private Question[] questions;

    private EmergencycallState ecState;

    public TMP_Text txtQ;
    public TMP_Text txtA;
    public TMP_Text txtTotPoints;
    public TMP_Text txtPoints;
    public Button btnReturn;

    private GameState state;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameRoot.Instance.GetComponent<GameState>();

        ecState = state.emergencycallState;
        questions = ecState.questions;

        ShowText();
    }


    public void ShowText()
    {
        if(questions[ecState.count].options == null)
        {
            btnReturn.gameObject.SetActive(true);
        }
        
        txtQ.text = questions[ecState.count].questionText;
        txtA.text = "";


    }

    public void ShowOption(int opt)
    {
        if (questions[ecState.count].options == null)
        {
            return;
        }

        txtA.text = questions[ecState.count].options[opt - 1].text;
        this.opt = opt;
    }


    public void Next()
    {
        if(opt == 0)
        {
            return;
        }

        point = questions[ecState.count].options[opt - 1].score;
        ecState.totPoint += point;
        ecState.count++;
        ShowText();

        txtTotPoints.text = $"Points: {ecState.totPoint}";
        if(point >= 0) txtPoints.text = $"+{point}";
        else txtPoints.text = point.ToString();
        opt = 0;

    }

    public void Return()
    {
        GameAction a = state.actions.Find(a => a.id == "tlf");
        a.additionalPoints += ecState.totPoint;
    }


}
