using System;
using UnityEngine;

public class PlayerCompanionActivation : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<InteractableAnimation>())
        {
            other.gameObject.GetComponent<InteractableAnimation>().animationactive = true;
        }
        
    }
    //Activates the animators of interacable objekts if the Collider of the Companion enters the Objekt.

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<InteractableAnimation>())
            {
            other.gameObject.GetComponent<InteractableAnimation>().animationactive = false;
            }
    }
    //Deactivates the Animation on the collider exiting the Collider of an Interactable Objekt.


}
