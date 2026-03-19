using TMPro;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    Vector3 originalScale;
    public float scaleMultiplier = 1.4f;

    public string text;
    public TMP_Text hoverText;

    public bool loadSceneOnClick = false;
    public string nextScene;

    void Start()
    {
        originalScale = transform.localScale;
        hoverText.gameObject.SetActive(false);
    }

    void OnMouseEnter()
    {
        hoverText.text = text;
        transform.localScale = originalScale * scaleMultiplier;
        hoverText.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        transform.localScale = originalScale;
        hoverText.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if(loadSceneOnClick)
        {
            GameManager.Instance.LoadScene(nextScene);
        }
        else
        {
            gameObject.SetActive(false);
            hoverText.gameObject.SetActive(false);
        }       
    }
}