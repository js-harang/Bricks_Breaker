using UnityEngine;

public class Bar : MonoBehaviour
{
    private void Update()
    {
        float xPosition = transform.position.x;
        float yPosition = transform.position.y;
        float zPosition = transform.position.z;
        float moveSpeed = 0.005f;

        xPosition += Input.GetAxis("Horizontal") * moveSpeed;

        transform.position = new Vector3(xPosition, yPosition, zPosition);
    }
}
