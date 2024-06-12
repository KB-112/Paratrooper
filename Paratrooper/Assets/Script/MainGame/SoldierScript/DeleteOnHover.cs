using UnityEngine;

public class DeleteOnHover : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DetectAndDeleteObject();
        }
    }

    void DetectAndDeleteObject()
    {
        // Create a ray from the mouse cursor position in the 2D world
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        // Perform the raycast and check if it hits any collider
        if (hit.collider != null)
        {
            Debug.Log("Hit");
            // Destroy the hit object
            Destroy(hit.collider.gameObject);
        }
    }
}
