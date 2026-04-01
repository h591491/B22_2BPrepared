using TMPro;
using UnityEngine;

public class MouseHover2 : MonoBehaviour
{
    public TMP_Text hoverText;
    public string text;

    private Collider2D myCollider;

    void Start()
    {
        Debug.Log("START works on " + gameObject.name);

        myCollider = GetComponent<Collider2D>();

        if (hoverText != null)
        {
            hoverText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (myCollider == null)
        {
            Debug.Log("No collider found");
            return;
        }

        if (Camera.main == null)
        {
            Debug.Log("No main camera found");
            return;
        }

        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector2 mousePoint = new Vector2(mouseWorldPos.x, mouseWorldPos.y);

        if (myCollider.OverlapPoint(mousePoint))
        {
            Debug.Log("Mouse is over icon");

            if (hoverText != null)
            {
                hoverText.text = text;
                hoverText.gameObject.SetActive(true);
            }
        }
        else
        {
            if (hoverText != null)
            {
                hoverText.gameObject.SetActive(false);
            }
        }
    }
}