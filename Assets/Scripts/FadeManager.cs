using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance; // 싱글톤 인스턴스

    public Image fadeImage; // 페이드 이미지
    public float fadeDuration = 1f; // 페이드 전환 시간

    private void Awake() // 싱글톤 적용
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬 로드될 때 FadeIn 실행
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) // 현재 씬, 불러올 씬
    {
        StartCoroutine(FadeIn()); // 씬이 로드되면 페이드 인 실행
    }

    public void LoadSceneWithFade(string sceneName) // 씬 전환
    {
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        float alpha = 1f;
        fadeImage.color = new Color(0, 0, 0, alpha);

        while (alpha > 0)
        {
            alpha -= Time.deltaTime / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        
        fadeImage.color = new Color(0, 0, 0, 0); // 알파값 정확히 0으로 설정
    }

    private IEnumerator FadeOut(string sceneName)
    {
        float alpha = 0f;
        fadeImage.color = new Color(0, 0, 0, alpha);

        while (alpha < 1)
        {
            alpha += Time.deltaTime / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(sceneName); // 씬 변경
    }
}