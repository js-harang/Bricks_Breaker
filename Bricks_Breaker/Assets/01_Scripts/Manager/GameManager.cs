using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Material[] bricksColor = new Material[7];

    public BallController ball = null;
    public bool isPlay = false;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public static GameManager instance;

    void Start()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        instance = this;

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
