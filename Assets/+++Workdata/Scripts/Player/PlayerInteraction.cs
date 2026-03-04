using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
   public Interactable interactableObject;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.GetComponent<Interactable>() != null) interactableObject = other.gameObject.GetComponent<Interactable>();
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject.GetComponent<Interactable>() != null ) interactableObject = null;
   }

   public void Interact()
   {
      print("Interact PlayerInteraction");
      if (interactableObject == null) return;
      
      interactableObject.onInteract?.Invoke();
      
      Debug.Log("Interacting with: " + interactableObject.name);
   }
}
