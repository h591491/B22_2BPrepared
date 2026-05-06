using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MouseHover : MonoBehaviour
{
    Vector3 originalScale;
    public float scaleMultiplier = 1.4f;

    public string text;
    public TMP_Text hoverText;
        
    public string objectID;

    public UnityEvent onClick;

    private bool active;
    private GameState state;


    void Start()
    {
        state = GameRoot.Instance.GetComponent<GameState>();

        if(state == null)
        {
            
            Debug.LogError("GameState not found!");
            enabled = false;
            return;

        }
        if(hoverText == null)
        {
            Debug.LogError("HoverText is null", this);
            enabled = false;
            return;
        
        }

        originalScale = transform.localScale;
        hoverText.gameObject.SetActive(false);

        active = true;
    }

    private void Update()
    {
        if (feedbackUI.UIBlocking)
        {
            active = false;
        }
        else
        {
            active = true;
        }
    }

    void OnMouseEnter()
    {
        if (!active)
        {
            return;
        }

        hoverText.text = text;
        transform.localScale = originalScale * scaleMultiplier;
        hoverText.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        if (!active)
        {
            return;
        }

        transform.localScale = originalScale;
        hoverText.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!active)
        {
            return;
        }

        CheckId();
        gameObject.SetActive(false);
        hoverText.gameObject.SetActive(false);

        onClick?.Invoke();
    }

    private void CheckId()
    {
        if (string.IsNullOrEmpty(objectID))
        {
            return;
        }
        state.CompleteAction(objectID);
    }

    public void SetActive(bool b)
    {
        active = b;

        if (!b)
        {
            transform.localScale = originalScale;
            hoverText.gameObject.SetActive(false);
        }
    }
}