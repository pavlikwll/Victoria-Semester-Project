using System;
using UnityEngine;

public class HollowAttackTrigger : MonoBehaviour
{
   [SerializeField] private int enemyDmg;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.tag == "Player")
      {
         other.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDmg);
      }
   }
}
