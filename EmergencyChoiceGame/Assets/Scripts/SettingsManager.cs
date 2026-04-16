using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    [Header("Settings Data")]
    public float masterVolume = 1f;
    public float musicVolume = 1f;

    [Header("UI References (persistent)")]
    public GameObject settingsOverlay;
    public GameObject panel;
    public GameObject backgroundDim;

    public float animationSpeed = 10f;

    private Vector3 targetScale;
    private bool isOpen = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (settingsOverlay != null)
                DontDestroyOnLoad(settingsOverlay);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadSettings();
    }

    void Start()
    {
        InitializeUI();
    }

    void Update()
    {
        if (panel != null)
        {
            panel.transform.localScale = Vector3.Lerp(
                panel.transform.localScale,
                targetScale,
                Time.deltaTime * animationSpeed
            );
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettings();
        }
    }

    void InitializeUI()
    {
        if (panel != null)
        {
            panel.transform.localScale = Vector3.zero;
            panel.SetActive(false);
        }

        if (backgroundDim != null)
            backgroundDim.SetActive(false);

        if (settingsOverlay != null)
            settingsOverlay.SetActive(false);

        isOpen = false;
    }

    public void OpenSettings()
    {
        if (settingsOverlay == null) return;

        settingsOverlay.SetActive(true);

        if (backgroundDim != null)
            backgroundDim.SetActive(true);

        if (panel != null)
        {
            panel.SetActive(true);
            panel.transform.localScale = Vector3.zero;
        }

        targetScale = Vector3.one;
        isOpen = true;
    }

    public void CloseSettings()
    {
        targetScale = Vector3.zero;
        isOpen = false;

        Invoke(nameof(HideSettings), 0.2f);
    }

    void HideSettings()
    {
        if (!isOpen && settingsOverlay != null)
        {
            settingsOverlay.SetActive(false);
        }
    }

    public void ToggleSettings()
    {
        if (settingsOverlay != null && settingsOverlay.activeSelf)
            CloseSettings();
        else
            OpenSettings();
    }

    public static void Toggle()
    {
        if (Instance != null)
            Instance.ToggleSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
    }
}