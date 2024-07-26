using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public newwww typewriterEffect;

    private void Start()
    {
        // Trigger the typewriter effect with the desired message
        string startMessage = "Let's turn this house into a dream home! Are you up for the challenge? 😀😀";
        typewriterEffect.StartTyping(startMessage);
    }
}