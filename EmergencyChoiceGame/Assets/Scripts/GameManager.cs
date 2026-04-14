using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timer = 0f;
    public string lastSavedScene = "intro_animation";
    public bool timerRunning = false;

    // Ordered list of every meaningful action the player has taken during this run.
    // Order matters: we use the index to check things like
    // "did the player call the emergency services before leaving the car?"
    // or "how early did they place the warning triangle?"
    private List<string> actionLog = new List<string>();

    // Keyed choices where the value matters, e.g. "triangle_placement" -> "far_back".
    // Use this when an action has variants you want to remember.
    private Dictionary<string, string> choices = new Dictionary<string, string>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (timerRunning)
        {
            timer += Time.deltaTime;
        }
    }

    public void SaveCheckpoint()
    {
        lastSavedScene = SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Action tracking
    // Records that the player did something. Idempotent: recording the same
    // action twice keeps only the first occurrence so order is preserved.
    public void RecordAction(string actionId)
    {
        if (string.IsNullOrEmpty(actionId)) return;
        if (!actionLog.Contains(actionId))
        {
            actionLog.Add(actionId);
            Debug.Log($"[GameManager] Recorded action: {actionId} (index {actionLog.Count - 1})");
        }
    }

    // True if the player has done this action at any point.
    public bool HasDoneAction(string actionId)
    {
        return actionLog.Contains(actionId);
    }

    // Returns the order in which an action was performed (0 = first action).
    // Returns -1 if the action was never performed.
    public int GetActionIndex(string actionId)
    {
        return actionLog.IndexOf(actionId);
    }

    // True if action A was performed before action B.
    // False if either is missing, or if B happened first.
    public bool DidActionBefore(string actionA, string actionB)
    {
        int a = GetActionIndex(actionA);
        int b = GetActionIndex(actionB);
        return a >= 0 && b >= 0 && a < b;
    }

    // Returns a copy of the action log in order. Useful for the paramedic
    // feedback at the end of the game.
    public List<string> GetActionLog()
    {
        return new List<string>(actionLog);
    }

    // Keyed choices

    // Records a choice with a value, e.g.
    // RecordChoice("triangle_placement", "far_back").
    public void RecordChoice(string key, string value)
    {
        choices[key] = value;
        Debug.Log($"[GameManager] Recorded choice: {key} = {value}");
    }

    // Returns the recorded choice value, or null if none was recorded.
    public string GetChoice(string key)
    {
        return choices.TryGetValue(key, out string value) ? value : null;
    }

    // Reset

    // Wipes all recorded state. Call when the player restarts from the main menu.
    public void ResetRun()
    {
        actionLog.Clear();
        choices.Clear();
        timer = 0f;
        timerRunning = false;
        lastSavedScene = "intro_animation";
    }

    // Backwards compatibility
    // Old API: a HashSet<string> called collectedObjects. We keep these wrappers
    // so the existing MouseHover and sceneloader_2b scripts keep working without
    // changes. New code should call RecordAction / HasDoneAction directly.

    public void SetObjectCollected(string id)
    {
        RecordAction(id);
    }

    public bool IsObjectCollected(string id)
    {
        return HasDoneAction(id);
    }
}