using UnityEngine;

public class InteractableAnimation : MonoBehaviour
{
    #region Variables
    
    public bool animationactive;
    private Animator animator;
    
    #endregion

    #region Unity Methods

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        animationactive = false;
        SetAnimationBool(animationactive);
    }
    
    
    public void SetAnimationBool(bool value)
    {
        animator.SetBool("AnimationActive", value);
        
    }

    #endregion
}
