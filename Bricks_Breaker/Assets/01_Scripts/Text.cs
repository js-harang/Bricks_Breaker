using TMPro;
using UnityEngine;

public class Text : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;

        gm.lifeTxt = gameObject.GetComponent<TMP_Text>();
    }
}
