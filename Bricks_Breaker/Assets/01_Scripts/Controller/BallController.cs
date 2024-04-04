using UnityEngine;

public class BallController : MonoBehaviour
{
    private GameManager gm = GameManager.Instance;

    public Vector3 movePos;
    float ballSpeed = 10f;

    private void Start()
    {
        gm.ball = this;
    }

    private void Update()
    {
        transform.position += movePos * ballSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            //if (gm.life > 0)
            //{
            //    gm.isPlaying = false;
            //    gm.life -= 1;
            //    movePos = Vector3.zero;
            //    transform.position = new Vector3(0f, -3f, 0f);
            //}
            //            else
            //            {
            //                // OS 환경별 종료
            //                #region
            //#if UNITY_EDITOR
            //                UnityEditor.EditorApplication.isPlaying = false;
            //#else
            //            Application.Quit();
            //#endif
            //                #endregion
            //            }
        }
        else
        {
            movePos = Vector3.Reflect(movePos, collision.contacts[0].normal).normalized;

            if (collision.gameObject.CompareTag("Bricks"))
            {
                string material = collision.gameObject.GetComponent<MeshRenderer>().material.name;

                switch (material)
                {
                    //case "1_Red (Instance)": gm.score += 10; break;
                    //case "2_Orange (Instance)": gm.score += 20; break;
                    //case "3_Yellow (Instance)": gm.score += 30; break;
                    //case "4_Green (Instance)": gm.score += 40; break;
                    //case "5_Blue (Instance)": gm.score += 50; break;
                    //case "6_Indigo (Instance)": gm.score += 60; break;
                    //case "7_Purple (Instance)": gm.score += 70; break;
                }

                Destroy(collision.gameObject);
            }
        }
    }
}
