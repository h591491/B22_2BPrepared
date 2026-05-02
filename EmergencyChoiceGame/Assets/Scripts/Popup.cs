using UnityEngine;

public class ObjectToggle : MonoBehaviour
{
    public void Show(GameObject target)
    {
        target.SetActive(true);
    }

    public void Hide(GameObject target)
    {
        target.SetActive(false);
    }

    public void Toggle(GameObject target)
    {
        target.SetActive(!target.activeSelf);
    }
}