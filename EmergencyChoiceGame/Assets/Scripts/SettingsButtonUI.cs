using UnityEngine;

public class SettingsButtonUI : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("Settings button clicked"); // debug

        SettingsManager.Toggle();
    }
}