using UnityEngine;

public class SettingsButtonUI : MonoBehaviour
{
    public void OnClick()
    {
        SettingsManager.Toggle();
    }
}