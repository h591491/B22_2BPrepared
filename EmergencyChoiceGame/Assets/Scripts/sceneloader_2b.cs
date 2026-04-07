using UnityEngine;

public class sceneloader_2b : MonoBehaviour
{
    public MouseHover[] objects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
}
