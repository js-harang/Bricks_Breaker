using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject loading_UI;
    public TMP_Text loadingText;
    public CanvasGroup fadeImg;
    float fadeDuration = 1.0f;

    [Space]

    public Material[] bricksColor = new Material[7];


    [SerializeField] Slider loadingBar;

    //Ball ball;
    GameObject pausePopup;



    bool isPausePopup = false;
    //public TMP_Text lifeTxt;

    //[Space]

    //public int life = 3;
    //public int score = 0;
    //public bool isPlaying = false;

    private void Start()
    {
        pausePopup = GameObject.Find("Canvas").transform.Find("Pause").gameObject;

    }

    private void Update()
    {
        //if (SceneManager.GetActiveScene().name == "02_Main")
        //{
        //lifeTxt.text = $"Life : {life}\nScore : {score}";
        //}

        if (SceneManager.GetActiveScene().name == "01_Start")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                EndGame();
        }

        //if (SceneManager.GetActiveScene().name == "02_Main")
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //        GameStart();

        //    if (Input.GetKeyDown(KeyCode.Escape))
        //        Pause();
        //}
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartBtn()
    {
        ChangeScene("02_Main");
    }

    private void ChangeScene(string scene)
    {
        fadeImg.DOFade(1, fadeDuration).OnStart(() => { fadeImg.blocksRaycasts = true; }).OnComplete(() => { StartCoroutine(LoadScene("02_Main")); });
    }

    IEnumerator LoadScene(string sceneName)
    {
        loading_UI.SetActive(true);

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        float timer = 0;

        while (!(async.isDone))
        {
            yield return null;

            if (async.progress < 0.9f)
                loadingBar.value = async.progress;
            else
            {
                timer += Time.unscaledDeltaTime;
                loadingBar.value = Mathf.Lerp(0.9f, 1f, timer);

                if (loadingBar.value >= 1f)
                {
                    async.allowSceneActivation = true;
                    yield break;
                }
            }

            loadingText.text = $"{loadingBar.value * 100:F0} %";
        }
    }

    public void ScoreBtn()
    {

    }

    public void EndGame()
    {

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
