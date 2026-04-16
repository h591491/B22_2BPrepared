using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSliderUI : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI valueText;

    public enum VolumeType { Master, Music }
    public VolumeType volumeType;

    void Start()
    {
        // Load correct value
        if (volumeType == VolumeType.Master)
            slider.value = SettingsManager.Instance.masterVolume;
        else
            slider.value = SettingsManager.Instance.musicVolume;

        UpdateText(slider.value);
        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    void OnSliderChanged(float value)
    {
        // Update value
        if (volumeType == VolumeType.Master)
            SettingsManager.Instance.masterVolume = value;
        else
            SettingsManager.Instance.musicVolume = value;

        // Save immediately
        SettingsManager.Instance.SaveSettings();

        UpdateText(value);
    }

    void UpdateText(float value)
    {
        int percent = Mathf.RoundToInt(value * 100);
        valueText.text = percent + "%";
    }
}