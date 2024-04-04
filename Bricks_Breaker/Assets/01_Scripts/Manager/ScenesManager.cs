using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance = null;

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

    [SerializeField] private CanvasGroup fadeImg;
    [Space]
    [SerializeField] private GameObject loading_UI;
    [Space]
    [SerializeField] private Slider loadingBar;
    [SerializeField] private TMP_Text loadingText;

    private float fadeDuration = 1.0f;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ChangeScene(string sceneName)
        => fadeImg.DOFade(1, fadeDuration)
            .OnStart(() => { fadeImg.blocksRaycasts = true; })
            .OnComplete(() => { StartCoroutine(LoadScene(sceneName)); });

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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        => fadeImg.DOFade(0, fadeDuration)
            .OnStart(() => { loading_UI.SetActive(false); })
            .OnComplete(() => { fadeImg.blocksRaycasts = false; });
}
