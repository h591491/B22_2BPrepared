using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Quitting game...");

        Application.Quit();

        // This makes it also stop in the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}