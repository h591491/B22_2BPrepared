using UnityEngine;

public class dragTriangle : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalScale;

    public float scaleMultiplier = 0.7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        isDragging = true;

        transform.localScale = originalScale * scaleMultiplier;

        // Finn offset slik at objektet ikke "hopper"
        Vector3 mouseWorldPos = GetMouseWorldPosition();
        offset = transform.position - mouseWorldPos;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mouseWorldPos = GetMouseWorldPosition();
            transform.position = mouseWorldPos + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Tilbakestill scale
        // transform.localScale = originalScale;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; // avstand fra kamera
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

}
