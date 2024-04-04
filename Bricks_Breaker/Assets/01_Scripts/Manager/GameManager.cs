using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;

            DontDestroyOnLoad(this);
        }
    }

    public TMP_Text lifeTxt;
    public int life;
    [HideInInspector] public int score = 0;

    public Material[] bricksColor = new Material[7];
    [Space]
    [HideInInspector] public BallController ball = null;
    public float moveSpeed = 0.05f;

    [HideInInspector] public bool isPlay = false;
    [HideInInspector] public bool isPossibleLeftMove = true;
    [HideInInspector] public bool isPossibleRightMove = true;

    void Start()
    {
        if (Instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }








    private void Update()
    {
        //if (SceneManager.GetActiveScene().name == "02_Main")
        //{
        //lifeTxt.text = $"Life : {life}\nScore : {score}";
        //}

        //if (SceneManager.GetActiveScene().name == "01_Start")
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //        EndGame();
        //}

        //if (SceneManager.GetActiveScene().name == "02_Main")
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //        GameStart();

        //    if (Input.GetKeyDown(KeyCode.Escape))
        //        Pause();
        //}
    }


    #region // 벽돌 색상 설정
    public Material ColorSetting()
    {
        int num = Random.Range(0, 6);

        return bricksColor[num];
    }
    #endregion
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
