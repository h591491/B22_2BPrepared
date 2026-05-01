using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    private TextMeshProUGUI text;
    private GameState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameRoot.Instance.GetComponent<GameState>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = state.timer.ToString("F1");
    }
}
