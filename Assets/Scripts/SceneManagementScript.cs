using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

public class SceneManagementScript : MonoBehaviour
{
    public Image fadeOutImage;
    public float fadeDuration = 1f;
    public static SceneManagementScript instance;
    private string previousScene;

    void Awake()
    {
        if (instance == null)
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
        previousScene = SceneManager.GetActiveScene().name;
        print(previousScene);
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


    public void JumpFromBedroomToKitchen()
    {
        TransitionToScene("Kitchen 1");
    }
    public void JumpFromBedroomToGame()
    {
        TransitionToScene("SampleScene");
    }
     public void LoadPreviousScene() {
        SceneManager.LoadScene(previousScene);
    }
    public void JumpFromGameToBedroom()
    {
        TransitionToScene("Bedroom 2");
    }
    public void JumpKitchenToWordle()
    {
        TransitionToScene("Wordle 2");
    }
    public void JumpFromLivingToGame()
    {
        TransitionToScene("Wordle 1");
    }
     public void JumpFromGameToLiving()
    {
        TransitionToScene("LivingRoom 2");
    }
    public void JumpFromLivingToBedroom()
    {
        TransitionToScene("Bedroom 1");
    }
     public void JumpFromExteriorToLiving()
    {
        TransitionToScene("LivingRoom 1");
    }

    public void JumpFromKitchenToLast()
    {
        TransitionToScene("Last");
    }

    public void JumpFromLastToStart()
    {
        TransitionToScene("Exterior");
    }
    public void JumpFromGameToKitchen()
    {
        TransitionToScene("Kitchen 2");
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
