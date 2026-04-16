using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverTextEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text text;
    public Color normalColor = Color.white;
    public Color hoverColor = new Color32(21, 39, 101, 255);

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = normalColor;
    }
}