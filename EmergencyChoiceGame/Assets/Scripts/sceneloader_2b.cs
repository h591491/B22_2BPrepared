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
            if (GameManager.Instance.IsObjectCollected(obj.objectID))
            {
                obj.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDialogueBox(string scenename)
    {
        this.scenename = scenename;
        task.SetActive(false);
        dialogue.SetActive(true);
    }

    public void HideDialogueBox()
    {
        dialogue.SetActive(false);
        task.SetActive(true);
    }

    public void placeTriangleNow()
    {
        GameManager.Instance.LoadScene("Minigame_warningTriangle");
    }

}
