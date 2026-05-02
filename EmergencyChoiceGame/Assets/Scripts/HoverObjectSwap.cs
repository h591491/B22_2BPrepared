using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class HoverObjectSwap : MonoBehaviour
{
    [Header("Hover Visuals")]
    public GameObject outline;

    [Header("Hover Text")]
    public string textToShow;
    public TextMeshProUGUI hoverText;

    [Header("Click Action")]
    public UnityEvent onClick;

    private void OnMouseEnter()
    {
        if (outline != null)
            outline.SetActive(true);

        if (hoverText != null)
            hoverText.text = textToShow;
    }

    private void OnMouseExit()
    {
        if (outline != null)
            outline.SetActive(false);

        if (hoverText != null)
            hoverText.text = "";
    }

    private void OnMouseDown()
    {
        onClick?.Invoke();
    }
}