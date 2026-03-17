using UnityEngine;

public class WhereToStopController : MonoBehaviour
{
    public void StopFurtherAway()
    {
        GameManager.Instance.stoppedFurtherAway = true;
        GameManager.Instance.stoppedNearby = false;
        GameManager.Instance.LoadScene("own_safety_inside_car");
    }

    public void StopNearby()
    {
        GameManager.Instance.stoppedNearby = true;
        GameManager.Instance.stoppedFurtherAway = false;
        GameManager.Instance.danger += 10;
        GameManager.Instance.LoadScene("own_safety_inside_car");
    }
}