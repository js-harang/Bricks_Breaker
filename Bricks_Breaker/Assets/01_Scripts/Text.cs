using TMPro;
using UnityEngine;

public class Text : MonoBehaviour
{
    private GameManager gm = GameManager.Instance;

    private void Start()
    {
        gm.lifeTxt = gameObject.GetComponent<TMP_Text>();
    }
}
