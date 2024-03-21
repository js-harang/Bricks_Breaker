using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Ball ball;
    GameObject pausePopup;

    bool isPausePopup = false;

    public TMP_Text lifeTxt;

    [Space]

    public int life = 3;
    public int score = 0;
    public bool isPlaying = false;

    [Space]

    public Material[] bricksColor = new Material[7];

    private void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        pausePopup = GameObject.Find("Canvas").transform.Find("Pause").gameObject;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Mains")
        {
            lifeTxt.text = $"Life : {life}\nScore : {score}";

            if (Input.GetKeyDown(KeyCode.Space))
                GameStart();

            if (Input.GetKeyDown(KeyCode.Escape))
                Pause();
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
        isPlaying = !isPlaying;
        isPausePopup = !isPausePopup;
        pausePopup.SetActive(isPausePopup);
    }

    public void Continue()
    {
        isPlaying = !isPlaying;
        isPausePopup = !isPausePopup;
        pausePopup.SetActive(isPausePopup);
    }

    public void StartBtn()
    {

    }

    public void ScoreBtn()
    {

    }

    public void EndGame()
    {

    }

    public void Exit()
    {
        #region
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        #endregion
    }
}
