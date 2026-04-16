using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UIHoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string textToShow;
    public TMP_Text hoverText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hover enter: " + gameObject.name);
        hoverText.text = textToShow;
        hoverText.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Hover exit: " + gameObject.name);
        hoverText.gameObject.SetActive(false);
    }
}