using UnityEngine;

public class Background : MonoBehaviour
{
    public Material backgroundMat;
    [Space]
    public float scrollSpeed;

    private void Update()
    {
        Vector2 dir = Vector2.left;
        backgroundMat.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
    }
}
