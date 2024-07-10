using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneManagementScript : MonoBehaviour
{
    public Image fadeOutImage;
    public float fadeDuration = 1f;
    public static SceneManagementScript instance;
     void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        if (fadeOutImage != null)
        {
            fadeOutImage.gameObject.SetActive(true);
            StartCoroutine(FadeIn());
        }
    }

    public void TransitionToScene(string sceneName)
    {
        if (fadeOutImage != null)
        {
            StartCoroutine(FadeOutAndLoadScene(sceneName));
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = fadeOutImage.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = 1f - Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeOutImage.color = color;
            yield return null;
        }
        fadeOutImage.gameObject.SetActive(false);
    }

    IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        fadeOutImage.gameObject.SetActive(true);
        float elapsedTime = 0f;
        Color color = fadeOutImage.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeOutImage.color = color;
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}