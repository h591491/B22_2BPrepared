using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsOverlay;

    public void OpenSettings()
    {
        settingsOverlay.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsOverlay.SetActive(false);
    }
}