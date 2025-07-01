using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class FadeManager : MonoBehaviour
{
    #region Properties
    [SerializeField] private float fadeSpeed = 1f;
    public Image fadePanel;
    public static FadeManager Instance { get; private set; }//Singleton
    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        fadePanel.gameObject.SetActive(true);
        Instance.FadeIn();//Se hace el efecto
    }
    #region Methods
    public void FadeIn()
    {
        StartCoroutine(Fade(1, 0)); // de negro a transparente
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0, 1)); // de transparente a negro
    }
    public void ChangeSceneFade(string SceneName)
    {
        StartCoroutine(ChangeSceneYield(SceneName));
    }
    #endregion

    #region Coroutine 
    IEnumerator Fade(float start, float end)
    {
        fadePanel.gameObject.SetActive(true);
        float time = 0f;
        Color color = fadePanel.color;
        color.a = start;
        fadePanel.color = color;

        while (time < 1f)
        {
            time += Time.deltaTime * fadeSpeed;
            float alpha = Mathf.Lerp(start, end, time);
            color.a = alpha;
            fadePanel.color = color;
            yield return null;
        }
        color.a = end;
        fadePanel.color = color;
        fadePanel.gameObject.SetActive(false);
    }
    IEnumerator ChangeSceneYield(string sceneName)
    {
        yield return StartCoroutine(Fade(0, 1));
        SceneManager.LoadScene(sceneName);
    }
    #endregion
}
