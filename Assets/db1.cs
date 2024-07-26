using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator secondAnimator; // Reference to the second GameObject's Animator

    // This method will be called at the end of the first animation
    public void TriggerSecondAnimation()
    {
        if (secondAnimator != null)
        {
            secondAnimator.Play("D_3_0"); // Play the second animation
        }
    }
}