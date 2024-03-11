using UnityEngine;

public class Ball : MonoBehaviour
{
    GameManager gm;

    public Vector3 movePos;
    float ballSpeed = 10f;

    private void Update()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        transform.position += movePos * ballSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            if (gm.life > 0)
            {
                gm.isPlaying = false;
                gm.life -= 1;
                movePos = Vector3.zero;
                transform.position = new Vector3(0f, -3f, 0f);
            }
            else
            {
                // OS 환경별 종료
                #region
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
                #endregion
            }
        }
        else
        {
            movePos = Vector3.Reflect(movePos, collision.contacts[0].normal).normalized;

            if (collision.gameObject.CompareTag("Bricks"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
