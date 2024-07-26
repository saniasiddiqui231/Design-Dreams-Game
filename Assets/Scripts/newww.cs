using System.Collections;
using UnityEngine;
using TMPro;

public class newwww : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Reference to the TextMeshProUGUI component
    public float typingSpeed = 0.05f; // Time between each character display

    private void Start()
    {
        // Example usage: Start the typewriter effect with the given message
        // string message = "Let's turn this house into a dream home! Are you up for the challenge?";
        // StartCoroutine(TypeText(message));
    }

    public IEnumerator TypeText(string message)
    {
        textComponent.text = ""; // Clear the text component

        foreach (char letter in message.ToCharArray())
        {
            textComponent.text += letter; // Add one character at a time
            yield return new WaitForSeconds(typingSpeed); // Wait for the specified time
        }
    }

    public void StartTyping(string message)
    {
        // Call this method to start typing a new message
        StartCoroutine(TypeText(message));
    }
}