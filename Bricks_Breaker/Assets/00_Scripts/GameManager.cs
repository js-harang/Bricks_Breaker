using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Ball ball;
    bool isPausePopup = false;

    public TMP_Text lifeTxt;

    [Space]

    public int life = 3;
    public int score = 0;
    public bool isPlaying = false;

    [Space]

    public GameObject pausePopup;
    public Material[] bricksColor = new Material[7];

    private void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
    }

    public void Update()
    {
        lifeTxt.text = $"Life : {life}\nScore : {score}";

        if (Input.GetKeyDown(KeyCode.Space))
            GameStart();

        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();

    }

    #region // 벽돌 색상 설정
    public Material ColorSetting()
    {
        int num = Random.Range(0, 6);

        return bricksColor[num];
    }
    #endregion

    public void GameStart()
    {
        if (!isPlaying)
        {
            ball.movePos = new Vector3(1f, 1f, 0f).normalized;
            isPlaying = true;
        }
    }

    public void Pause()
    {
        pausePopup.SetActive(!isPausePopup);
    }
}
