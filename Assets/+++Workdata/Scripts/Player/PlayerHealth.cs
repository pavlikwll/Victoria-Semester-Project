using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   [Header("Health Settings")]
   
   [SerializeField] private int _maxHealth = 100;
   [SerializeField] private int _currentHealth = 100;
   
   private Playercontroller playerController;
   
   public Image healthBar;

   #region Methods

   private void Awake()
   {
      _currentHealth = _maxHealth;
      playerController = GetComponent<Playercontroller>();
      UpdateHealthBar();
   }
   
    private void Update()
   {
      if (Input.GetKeyDown(KeyCode.H))
         TakeDamage(10);
   } 
   
   private void UpdateHealthBar()
   {
      if (healthBar == null)
      {
         return;
      }
      healthBar.fillAmount = Mathf.InverseLerp(0f, _maxHealth, _currentHealth);
   }

   private void PlayerDeath()
   {
      playerController.GameOver();
      
   }

   public void TakeDamage(int amount)
   {
   
      _currentHealth -= amount;
      if (_currentHealth < 0)
      {
         _currentHealth = 0;
      }
      
      UpdateHealthBar();
      
      if (_currentHealth <= 0)
      {
         PlayerDeath();
      }
   }
   
   public void Heal(int amount)
   {
      _currentHealth += amount;

      if (_currentHealth > _maxHealth)
      {
         _currentHealth = _maxHealth;
      }

      UpdateHealthBar();
   }

   #endregion
}
