using UnityEngine;

public class sceneloader_2a : MonoBehaviour
{
    public MouseHover[] objects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var obj in objects)
        {
            bool hide = false;

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
}
