using UnityEngine;

public class Bar : MonoBehaviour
{
    float xPosition, yPosition, zPosition;
    float moveSpeed = 0.05f;
    bool isPossibleLeftMove = true;
    bool isPossibleRightMove = true;

    private void Update()
    {
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        zPosition = transform.position.z;

        float getAxis = Input.GetAxis("Horizontal");

        xPosition += getAxis * moveSpeed;

        if (!isPossibleLeftMove && getAxis < 0)
        {
            Debug.Log("왼쪽 한계점");
        }
        else if (!isPossibleRightMove && getAxis > 0)
        {
            Debug.Log("오른쪽 한계점");
        }
        else
            transform.position = new Vector3(xPosition, yPosition, zPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Wall (3)")
            isPossibleLeftMove = false;
        else if (other.name == "Wall (4)")
            isPossibleRightMove = false;
        else
            Debug.Log("bar trigger bug");
    }

    private void OnTriggerExit(Collider other)
    {
        isPossibleLeftMove = true;
        isPossibleRightMove = true;
    }
}
