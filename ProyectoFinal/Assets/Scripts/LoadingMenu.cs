using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingMenu : MonoBehaviour
{
    public int idScene;

    [SerializeField]
    private Text txtLoading;
    [SerializeField]
    private Slider sliderLoading;

    private AsyncOperation async;
    private CanvasGroup canvasGroup;
    private Coroutine coroutineFadeOut = null;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        StartCoroutine(StartLoadScene());

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (async != null)
        {
            float progresScene = async.progress;
            txtLoading.text = "Loading... " + (progresScene * 100) + "%";
            sliderLoading.value = progresScene;
        }
    }

    IEnumerator StartFade(float value, float duration)
    {            
        float startAlpha = canvasGroup.alpha;
        float time = 0;
        while(time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, value, time/duration);

            time += Time.unscaledDeltaTime;
            
            yield return null;
        }
    }

    IEnumerator StartLoadScene()
    {
        yield return StartCoroutine(StartFade(1,3));
        async = SceneManager.LoadSceneAsync(idScene);
        while(!async.isDone)
        {
            yield return null;
        }
        yield return StartCoroutine(StartFade(0,3));
        Destroy(this.gameObject);
    }
}

//Para pausar el juego (Time.timeScale = 0;)
