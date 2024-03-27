using System.Threading.Tasks;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameManager gm;
    private ScenesManager sm;

    private void Start()
    {
        gm = GameManager.Instance;
        sm = ScenesManager.Instance;
    }

    public void GameStartBtn()
    {
        sm.ChangeScene("02_Main");

        gm.ball = GameObject.Find("Ball").GetComponent<BallController>();
    }

    public void GameScoreBtn()
    {

    }

    public void GameStart()
    {
        gm.ball.movePos = new Vector3(1f, 1f, 0f).normalized;
        gm.isPlay = true;
    }
}
