using UnityEngine;
using UnityEngine.UI;

public class ButtonManagerScript : MonoBehaviour
{
    public Button myButton; // Reference to the button
    private int score = 100;   // Initial score
    public GameObject scoreObject;
    private Text scoreText;
    public static ButtonManagerScript bms;
    void Awake(){
        if (bms != null){
            bms = this;
        }
    }

    void Start()
    {
        // Ensure the button is initially disabled
        myButton.interactable = false;
        //scoreText = scoreObject.GetComponent<Text>();
    }

    void Update()
    {
       // print(scoreText);
        // Check the score in every frame
        /*if (GetScoreFromText() >= score)
        {
            // Enable the button if score is 200 or more
            myButton.interactable = true;
        }
        else
        {
            // Otherwise, keep the button disabled
            myButton.interactable = false;
        }*/
    }
    public void EnableButton(){
        myButton.interactable = true;
    }

    // Method to increase score (for demonstration purposes)
    
}