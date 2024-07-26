using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TransitionScenes : MonoBehaviour
{
    public GameObject playButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void JumpToBedroomScene()
    {
        SceneManagementScript.instance.JumpFromBedroomToKitchen();    
    }
    public void jumpToMatchMakerScene(){
        SceneManagementScript.instance.JumpFromBedroomToGame();
    }
    public void jumpToWordle(){
        
    }
    public void EnablePlayButton(){
        playButton.gameObject.SetActive(true);
        print("enabled play button");

    }
}
