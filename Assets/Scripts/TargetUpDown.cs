using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetUpDown : MonoBehaviour
    {
    [SerializeField] private GameObject Target = null;
    private Animator myAnimator;
    private bool isAnimationPlaying = false;

    public void Start()
    {
        // Get the Animator component attached to the same GameObject
        myAnimator = GetComponent<Animator>();
        DeactivateTarget();
    }

    public void DeactivateTarget(){
        Target.SetActive(false);
    }

    public void ToggleAnimation()
    {
        DeactivateTarget();

        Target.SetActive(true);
        // Toggle the animation state
        isAnimationPlaying = !isAnimationPlaying;

        // Set the animator parameter to control the animation
        myAnimator.SetBool("Target", isAnimationPlaying);

        // Optionally, you can add additional logic based on the animation state
        if (isAnimationPlaying)
        {
           myAnimator.SetTrigger("TargetUp");
        }
        else
        {
            myAnimator.SetTrigger("TargetDown");
        }
    }
}
