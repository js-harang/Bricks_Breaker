using UnityEngine;

public class BricksController : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = ColorSetting();
    }

    public Material ColorSetting()
    {
        int num = Random.Range(0, 6);

        return GameManager.Instance.bricksColor[num];
    }
}
