using TMPro;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    Vector3 originalScale;
    public float scaleMultiplier = 1.4f;

    public string text;
    public TMP_Text hoverText;

    public bool loadSceneOnClick = false;
    public bool saveState = false;
    public string nextScene;

    public string objectID;

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
            if (saveState)
            {
                GameManager.Instance.SetObjectCollected(objectID);
            }
            GameManager.Instance.LoadScene(nextScene);
        }
        else
        {
            GameManager.Instance.SetObjectCollected(objectID);

            gameObject.SetActive(false);
            hoverText.gameObject.SetActive(false);
        }       
    }
}