using UnityEngine;

public class TrianglePlacementConfirm : MonoBehaviour
{
    public Collider2D triangleCollider;

    public string returnScene = "2b_bringFromCar";

    public Collider2D farBackZone;

    public Collider2D nearZone;

    public Collider2D besideZone;

    public void OnConfirmClicked()
    {
        string placement = ResolvePlacement();

        GameManager.Instance.RecordAction("placed_triangle");
        GameManager.Instance.RecordChoice("triangle_placement", placement);

        GameManager.Instance.LoadScene(returnScene);
    }

    private string ResolvePlacement()
    {
        if (triangleCollider == null)
        {
            Debug.LogWarning("TrianglePlacementConfirm: triangleCollider is not assigned.");
            return "missed";
        }

        Vector2 trianglePos = triangleCollider.transform.position;

        Debug.Log($"Triangle position: {trianglePos}");
        // Check the GOOD zone first so an overlap area resolves to the better placement.
        if (farBackZone != null && farBackZone.OverlapPoint(trianglePos))
            return "far_back";

        if (nearZone != null && nearZone.OverlapPoint(trianglePos))
            return "near";

        if (besideZone != null && besideZone.OverlapPoint(trianglePos))
            return "beside";

        return "missed";
    }
}