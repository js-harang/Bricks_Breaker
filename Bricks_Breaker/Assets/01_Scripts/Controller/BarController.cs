using UnityEngine;

public class BarController : MonoBehaviour
{
    private GameManager gm = GameManager.Instance;

    private float getAxis;

    private void Update()
    {
        getAxis = Input.GetAxis("Horizontal");

        if (!(!gm.isPossibleLeftMove && getAxis < 0) && !(!gm.isPossibleRightMove && getAxis > 0))
            transform.position = new Vector3(
                transform.position.x + getAxis * gm.moveSpeed,
                transform.position.y,
                transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Wall (3)")
            gm.isPossibleLeftMove = false;
        else if (other.name == "Wall (4)")
            gm.isPossibleRightMove = false;
    }

    private void OnTriggerExit(Collider other)
    {
        gm.isPossibleLeftMove = true;
        gm.isPossibleRightMove = true;
    }
}
