using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetUpDown : MonoBehaviour
    {
<<<<<<< HEAD
    [SerializeField] private GameObject Target = null;
=======
    //[SerializeField] private GameObject Target = null;
>>>>>>> parent of 9411cf4 (revert)
    private Animator myAnimator;
    private bool isAnimationPlaying = false;

    public void Start()
    {
<<<<<<< HEAD
        
        // Get the Animator component attached to the same GameObject
        myAnimator = GetComponent<Animator>();
        DeactivateTarget();
    }

    public void DeactivateTarget(){
       Target.SetActive(false);
    }
=======
        // Get the Animator component attached to the same GameObject
        myAnimator = GetComponent<Animator>();
    //    DeactivateTarget();
    }

    //public void DeactivateTarget(){
    //    Target.SetActive(false);
    //}
>>>>>>> parent of 9411cf4 (revert)

    public void ToggleAnimation()
    {
    //    DeactivateTarget();

<<<<<<< HEAD
        Target.SetActive(true);
        
=======
    //    Target.SetActive(true);
>>>>>>> parent of 9411cf4 (revert)
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
