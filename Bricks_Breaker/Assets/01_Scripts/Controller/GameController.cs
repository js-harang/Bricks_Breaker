using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameManager gm = GameManager.Instance;
    private ScenesManager sm = ScenesManager.Instance;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "02_Main")
        {
            gm.lifeTxt.text = $"Life : {gm.life}\nScore : {gm.score}";

            if (Input.GetKeyDown(KeyCode.Space))
                GameStart();
        }
    }

    public void GameStartBtn() => sm.ChangeScene("02_Main");

    public void GameScoreBtn()
    {

    }

    public void GameStart()
    {
        gm.ball.movePos = new Vector3(1f, 1f, 0f).normalized;
        gm.isPlay = true;
    }
}
