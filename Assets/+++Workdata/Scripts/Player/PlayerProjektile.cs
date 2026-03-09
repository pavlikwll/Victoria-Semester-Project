using System;
using UnityEngine;

public class PlayerProjektile : MonoBehaviour
{
   #region Variables

   [SerializeField]private float projectileSpeed;
   [SerializeField]private int projectileDamage;
   [SerializeField]private float projectileLifetime;
   private float _projectileTimer;
   private Rigidbody2D _projectileRigidBody;
   private Playercontroller _playercontroller;
   private Animator _anim;
   
   
   

   #endregion
   
   #region Unity Events

   private void Awake()
   {
      _projectileRigidBody = GetComponent<Rigidbody2D>();
      _projectileTimer = 0;
      _anim = GetComponentInChildren<Animator>();
   }
   
   #endregion

   #region Methods

   public void ProjektileAttack(Vector2 direction, Playercontroller playercontroller)
   {
      //print(direction);
      _playercontroller = playercontroller;
      _projectileRigidBody.AddForce(direction * projectileSpeed, ForceMode2D.Impulse);
      if (direction.x < 0)
      {
         transform.rotation = Quaternion.Euler(0, 180, 0);
      }
      else
      {
         transform.rotation = Quaternion.Euler(0, 0, 0);
      }
   }

   private void FixedUpdate()
   {
      _projectileTimer = _projectileTimer + Time.fixedDeltaTime;
      if (_projectileTimer > projectileLifetime)
         ProjectileDestruction();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Ground")) ProjectileDestruction();
      if (other.CompareTag("Enemy"))
      {
         other.gameObject.GetComponent<EnemyHP>().TakePurification(projectileDamage);
      }
      //if (collision.gameObject.CompareTag("Enemy"))
         //collision.gameObject.GetComponent<EnemyHp(_projectileDamage)>();
         
      
   }

   private void ProjectileDestruction()
   {
      Destroy(gameObject);
   }
   

   private void OnDestroy()
   {
      _playercontroller._starStateAvailable = StarStateAvailable.True;
   }

   #endregion
}
