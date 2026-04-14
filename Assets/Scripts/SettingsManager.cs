using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    // ----------------------
    // SETTINGS DATA
    // ----------------------
    public float masterVolume = 1f;
    public float musicVolume = 1f;

    // ----------------------
    // UI REFERENCES
    // ----------------------
    public GameObject settingsOverlay;
    public GameObject panel;
    public GameObject backgroundDim;

    public float animationSpeed = 10f;

    private Vector3 targetScale;
    private bool isOpen = false;

    void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadSettings();

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SetupUI();
    }

    void Update()
    {
        // Animate panel
        if (settingsOverlay != null && settingsOverlay.activeSelf && panel != null)
        {
            panel.transform.localScale = Vector3.Lerp(
                panel.transform.localScale,
                targetScale,
                Time.deltaTime * animationSpeed
            );
        }

        // ESC toggle
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettings();
        }
    }

    // ----------------------
    // SCENE LOADING HOOK
    // ----------------------
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetupUI();
    }

    void SetupUI()
    {
        GameObject overlay = GameObject.Find("SettingsOverlay");

        if (overlay != null)
        {
            settingsOverlay = overlay;

            Transform panelTransform = overlay.transform.Find("SettingsPanel");
            Transform dimTransform = overlay.transform.Find("BackgroundDim");

            if (panelTransform != null)
                panel = panelTransform.gameObject;

            if (dimTransform != null)
                backgroundDim = dimTransform.gameObject;

            // Reset UI state
            panel.transform.localScale = Vector3.zero;
            panel.SetActive(false);

            if (backgroundDim != null)
                backgroundDim.SetActive(false);

            settingsOverlay.SetActive(false);
            isOpen = false;
        }
    }

    // ----------------------
    // OPEN / CLOSE SETTINGS
    // ----------------------
    public void OpenSettings()
    {
        if (settingsOverlay == null) return;

        settingsOverlay.SetActive(true);

        if (backgroundDim != null)
            backgroundDim.SetActive(true);

        panel.SetActive(true);
        panel.transform.localScale = Vector3.zero;

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

    // ----------------------
    // TOGGLE (USED BY BUTTON + ESC)
    // ----------------------
    public void ToggleSettings()
    {
        if (settingsOverlay != null && settingsOverlay.activeSelf)
            CloseSettings();
        else
            OpenSettings();
    }

    // ----------------------
    // STATIC ACCESS (KEY PART 🔥)
    // ----------------------
    public static void Toggle()
    {
        if (Instance != null)
        {
            Instance.ToggleSettings();
        }
    }

    // ----------------------
    // SAVE SYSTEM
    // ----------------------
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