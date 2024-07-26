using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd; // Subscribe to the event
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("introConnect"); // Replace with your scene name
    }
}