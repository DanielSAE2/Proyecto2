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
        async = SceneManager.LoadSceneAsync(idScene);

        canvasGroup = GetComponent<CanvasGroup>();

        StartCoroutine(StartFade(1, 10));

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (canvasGroup.alpha <= 0.9f && coroutineFadeOut == null)
        {
            if (!async.isDone)
            {
                float progresScene = async.progress + 0.1f;
                txtLoading.text = "Loading... " + (progresScene * 100) + "%";
                sliderLoading.value = progresScene;
            }
            else
            {
                coroutineFadeOut = StartCoroutine(StartFade(0,5f));
            }
        }
        if (coroutineFadeOut != null && canvasGroup.alpha <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator StartFade(float value, float duration)
    {            
        float alpha = canvasGroup.alpha;
        float time = 0;
        while(time < duration)
        {
            alpha = Mathf.Lerp(alpha, value, time/duration);
            canvasGroup.alpha = alpha;

            time += Time.unscaledDeltaTime;
            
            yield return null;
        }
    }
}

//Para pausar el juego (Time.timeScale = 0;)
