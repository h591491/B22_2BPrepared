using System.Collections.Generic;

[System.Serializable]
public class SceneFeedback
{
    public string sceneName;

    public List<string> goodRequiredActions;
    public List<string> mediumRequiredActions;

    public string goodText;
    public string mediumText;
    public string badText;
}
