using UnityEngine;

public class FollowupController : MonoBehaviour
{
    public string returnScene;

    private SceneController sceneController;

    void Start()
    {
        sceneController = GameRoot.Instance.GetComponent<SceneController>();
    }

    public void ShowPanel(GameObject panelToShow)
    {
        Transform parent = panelToShow.transform.parent;
        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(false);
        }
        panelToShow.SetActive(true);
    }

    public void ReturnToTriage()
    {
        sceneController.LoadScene(returnScene);
    }
}