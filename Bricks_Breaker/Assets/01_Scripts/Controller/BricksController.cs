using UnityEngine;

public class BricksController : MonoBehaviour
{
    private GameManager gm = GameManager.Instance;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = ColorSetting();
    }

    public Material ColorSetting()
    {
        int num = Random.Range(0, 6);

        return gm.bricksColor[num];
    }
}
