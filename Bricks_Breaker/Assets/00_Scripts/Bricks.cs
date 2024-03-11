using UnityEngine;

public class Bricks : MonoBehaviour
{
    private void Start()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        gameObject.GetComponent<MeshRenderer>().material = gm.ColorSetting();
    }
}
