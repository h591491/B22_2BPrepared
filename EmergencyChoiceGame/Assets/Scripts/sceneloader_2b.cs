using System;
using UnityEngine;

public class sceneloader_2b : MonoBehaviour
{
    public GameObject task;
    public GameObject dialogue;
    public MouseHover[] objects;

    private string scenename;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogue.SetActive(false);
        task.SetActive(true);

        foreach (var obj in objects)
        {
            bool hide = false;

            // Sjekk collected
            if (GameManager.Instance.IsObjectCollected(obj.objectID))
            {
                hide = true;
            }

            // Sjekk state
            if (GameManager.Instance.CheckObjectState(obj.objectID))
            {
                hide = true;
            }

            obj.gameObject.SetActive(!hide);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDialogueBox(string scenename)
    {
        SetMouseHoverActive(false);

        this.scenename = scenename;
        task.SetActive(false);
        dialogue.SetActive(true);
    }

    public void HideDialogueBox()
    {
        // Velger å ikke plassere trekanten nå:
        var ta = GameManager.Instance.actions.Find(a => a.id == "triangle");
        ta.done = false;
        
        SetMouseHoverActive(true);
        dialogue.SetActive(false);
        task.SetActive(true);
    }

    public void placeTriangleNow()
    {
        GameManager.Instance.LoadScene(scenename);
    }

    public void SetMouseHoverActive(bool state)
    {
        foreach (var obj in objects)
        {
            obj.SetActive(state);
        }
    }
}
