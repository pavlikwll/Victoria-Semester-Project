using System;
using UnityEngine;

public class HollowAttack : MonoBehaviour
{
   #region Variables

   public GameObject attackTarget;
   [SerializeField] private HollowMovement hollowMovement;

   #endregion

   #region Methods

   private void OnTriggerEnter2D(Collider2D other)
   {

       if (other.gameObject.CompareTag("Player"))
       {
           if (other.gameObject.GetComponent<Playercontroller>()._starStateAvailable ==
               StarStateAvailable.False) return;
           attackTarget = other.gameObject;
           hollowMovement.SetActionState();
       }

   }

   private void OnTriggerExit2D(Collider2D other)
   {
       if (other.gameObject.CompareTag("Player"))
       {
           attackTarget  = null;
           hollowMovement.SetActionState();
       
       }
      
   }

   #endregion
}
