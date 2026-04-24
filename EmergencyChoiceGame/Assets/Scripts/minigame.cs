using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class minigame : MonoBehaviour
{
    public Collider2D outerZone;
    public Collider2D innerZone;
    public Transform triangle;

    private string placement = "";

    public TMP_Text task1;
    public TMP_Text task2;
    public TMP_Text feedback;

    public Button btn;

    private GameAction action = GameManager.Instance.actions.Find(a => a.id == "triangle");

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        feedback.gameObject.SetActive(false);
        btn.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void CheckPlacement()
    {
        Vector2 pos = triangle.position;

        if (innerZone.OverlapPoint(pos))
        {
            placement = "Perfect";
            action.doneText += ", and it was placed correctly";
        }
        else if (outerZone.OverlapPoint(pos))
        {
            placement = "Close";
            action.doneText += ", but the placement was slightly off";
        }
        else
        {
            placement = "Wrong position";
            action.doneText += ", and the placement was incorrect";
        }
    }

    public void Confirim()
    {
        CheckPlacement();
        task1.gameObject.SetActive(false);
        task2.gameObject.SetActive(false);

        feedback.gameObject.SetActive(true);
        feedback.text = placement;

        btn.gameObject.SetActive(true);
    }


}
