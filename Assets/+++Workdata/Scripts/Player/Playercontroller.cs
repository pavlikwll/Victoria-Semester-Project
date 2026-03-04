using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

#region Enums
public enum PlayerDirectionState{FacingRight, FacingLeft}
// Speichert die Blickrichtung des Spielers
public enum PlayerActionState{Idle, Walk, InAir}
// Speichert den aktuellen Bewegungszustand
public enum StarStateAvailable{True, False}
// Gibt an, ob aktuell ein Projektil geworfen werden darf

//Enums that are used within and without of the class. Used for Object States.
#endregion
public class Playercontroller : MonoBehaviour
{
   #region Inspector Variables
   [Header("SoundClips")]
   [SerializeField] private AudioClip[] _stepSound; // Array mit Schrittgeräuschen
   
   [Header("PlayerMovement")]
   [SerializeField]private float _playerSpeed; // Laufgeschwindigkeit
   [SerializeField]private float _playerJumpForce;// Sprungkraft
   [SerializeField]private PlayerDirectionState _playerDirectionState;// Blickrichtung
   
   [Header("GroundCheck")]
   [SerializeField]private bool _isGrounded;// Ist der Spieler am Boden?
   [SerializeField]private float _groundCheckRadius;// Radius für Bodenkontrolle
   [SerializeField]private LayerMask _groundLayer;// Welche Layer als Boden zählen
   [SerializeField]private Vector2 _groundCheckPos;// Offset für GroundCheck
   
   [Header("Projectile")]
   [SerializeField]private GameObject _projectileSpawn;// Spawnpunkt des Projektils
   [SerializeField]private GameObject _projectilePrefab;// Projektil-Prefab
   public StarStateAvailable _starStateAvailable;// Ob das Projektil verfügbar ist
   
   [Header("PlayerInteractions")]
   [SerializeField]private PlayerPlatformHandler playerPlatformHandler;// Plattform-Logik wie ausm Untericht
   [SerializeField]private PlayerInteraction playerInteraction;// Interaktions-Logik nur schlechter als aus dem Untericht
   
   [Header("UI")]
   [SerializeField] private GameOverManager _gameOverManager;// Game Over Screen
   [SerializeField] private PauseMenu _pauseMenu;// Pause Menü
   
   
   

   
   // Variables that can be changed inside the Inspector (public and Serialised Field)
   #endregion

   #region Private Variables
   
   
   private PlayerActionState _playerActionState;
   private bool isWalking = false;// Wird aktuell gelaufen?
   private float _currentSpeed;// Aktuelle Geschwindigkeit
   private Vector2 _attackdirection;// Richtung des Projektils

   
   private Rigidbody2D _rb;// Referenz auf Rigidbody
   private Animator _anim;// Referenz auf Animator

   // Variables that are private to this Script and that are not ment to be changed inside the Inspector

   #endregion

   #region Input Variables
   
   public Vector2 _moveInput;
   public InputSystem_Actions _inputSystemActions;
   private InputAction _moveAction;
   private InputAction _jumpAction;
   private InputAction _crouchAction;
   private InputAction _attackAction;
   private InputAction _interactAction;
   private InputAction _pauseAction;
   // Input Variables for InputmapInputs
   

   #endregion

   #region Unity Event Functions

   private void Awake()
   {
      
      _rb = GetComponent<Rigidbody2D>();
      _anim = GetComponentInChildren<Animator>();
      //Saving components to Variables
      _inputSystemActions = new InputSystem_Actions();
      _currentSpeed = _playerSpeed;
      //_currentspeed has to be set to the right speed (to do change current speed based on Movmentstate)
      SetInput();
      _playerDirectionState = PlayerDirectionState.FacingRight;
      _attackdirection = Vector2.right;
      _starStateAvailable = StarStateAvailable.True;
      _anim.SetBool("IsGrounded", true);
      //sets all Important Variables to there designatet Starting Value.
      DisablePlayerImput();

     
      
      
   }

   private void OnEnable()
   {
      _inputSystemActions.Enable();
      _moveAction.performed += Move;
      _moveAction.canceled += Move;
      _jumpAction.performed += Jump;
      _attackAction.performed += Attack;
      _interactAction.performed += Interact;
      _pauseAction.performed += Pause;
      _crouchAction.performed += Crouch;
      //subscribing to Imputactions
      
      StartCoroutine(PlaySoundsRepeated());
      //Enables Coroutines
      //Somethin something SoundManager who cares?
   }

   private void FixedUpdate()
   {
      _rb.linearVelocityX = _moveInput.x * _currentSpeed;
      _anim.SetFloat("MovementValue", _rb.linearVelocityX);
      //Animator MovementValue set to enable MovmentBlendtree.
      CheckIsGrounded();
      //Casting Groundcheck to Return _isGrounded = true
      PlayerDirection();
      if (_playerDirectionState == PlayerDirectionState.FacingRight)
      {
         _anim.SetFloat("PlayerDirection", 1);
      }
      else if (_playerDirectionState == PlayerDirectionState.FacingLeft)
         {
         _anim.SetFloat("PlayerDirection", -1);
         }
      //animation VAlues for Direction

      if (_isGrounded == true)
         _anim.SetBool("IsGrounded", true);
      else
      {
         _anim.SetBool("IsGrounded", false);
      }
      //Animation Values for Grounded

      
   }

   private void OnDisable()
   {
      
      _moveAction.performed -= Move;
      _moveAction.canceled -= Move;
      _jumpAction.performed -= Jump;
      _attackAction.performed -= Attack;
      _interactAction.performed -= Interact;
      _pauseAction.performed -= Pause;
      _crouchAction.performed -= Crouch;
      //Unsubscribing from InputActions
      _inputSystemActions.Player.Disable();
      _inputSystemActions.UI.Disable();
      _inputSystemActions.Disable();

   }
   #endregion

   #region Input Methods

   private void SetInput()
   {
      _inputSystemActions = new InputSystem_Actions();
      _moveAction = _inputSystemActions.Player.Move;
      _jumpAction = _inputSystemActions.Player.Jump;
      _crouchAction = _inputSystemActions.Player.Crouch;
      _attackAction = _inputSystemActions.Player.Attack;
      _interactAction = _inputSystemActions.Player.Interact;
      _pauseAction = _inputSystemActions.Player.Pause;
      //Method sets the Variables for the Playerinputs to the designated Variables and gets invoked in Awake().
   }
   private void Move(InputAction.CallbackContext ctx)
   {
      _moveInput = ctx.ReadValue<Vector2>();
      if (_moveInput.x > 0)_playerDirectionState = PlayerDirectionState.FacingRight;
      if (_moveInput.x < 0)_playerDirectionState = PlayerDirectionState.FacingLeft;

      if (_moveInput.y < 0) playerPlatformHandler.TryDisableOneWayEffector();
      
      
      /*if (_isGrounded && _moveAction.ReadValue<Vector2>() != Vector2.zero)
      {
         isWalking = true;
         InvokeRepeating(nameof (WalkingSound), 0f, 0.35f);
      }
      else
      {
         isWalking = false;
         CancelInvoke(nameof(WalkingSound));*/
      //keine gute Variante für Sound :( 
   }

   private void Jump(InputAction.CallbackContext ctx)
   {
      if (_isGrounded != true) return;
      _rb.AddForce(Vector2.up * _playerJumpForce, ForceMode2D.Impulse);
      //Player Jump 
      
   }

   private void Attack(InputAction.CallbackContext ctx)
   { 
      if (_starStateAvailable != StarStateAvailable.True) return;
      GameObject projectile = Instantiate(_projectilePrefab, _projectileSpawn.transform.position, Quaternion.identity);// Projektil erzeugen
      projectile.GetComponent<PlayerProjektile>().ProjektileAttack(_attackdirection, this);// Angriff ausführen
      _starStateAvailable = StarStateAvailable.False;

      AnimationAction(42); // Angriffsanimation triggern
     
   }

   private void Interact(InputAction.CallbackContext ctx)// Interact Action
   {
      print("Interact");
      playerInteraction.Interact();
   }

   private void Pause(InputAction.CallbackContext ctx)// Pausiert das Game
   {
      if (_pauseMenu == null) return;

      if (PauseMenu.isPaused)
      {
         _pauseMenu.ResumeGame();
      }
      else
      {
         _pauseMenu.OpenPauseMenu();
      }
   }

   private void Crouch(InputAction.CallbackContext ctx)// Stern-Verfügbarkeit toggeln
   {
      if (_starStateAvailable == StarStateAvailable.True)
      {
         _starStateAvailable = StarStateAvailable.False;
      }
      else
      {
         _starStateAvailable = StarStateAvailable.True;
      }
   }

   private void PlayerDirection()
   {
      /*
       wenn idle animation - kein trasform rotation
      if (Mathf.Abs(_moveInput.x) < 0.1f)
      {
         return;
      }
      */
      //bitte was Wowa?
      
      if (_playerDirectionState == PlayerDirectionState.FacingRight)
      {
         //print("reset");
         gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
         _attackdirection = Vector2.right;
      }
      if (_playerDirectionState == PlayerDirectionState.FacingLeft)
      {
         gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
         _attackdirection = Vector2.left;
      }
   }

   #region Physics Methods

   private void CheckIsGrounded() //Prüft ob Groundcheck den Boden BErührt
   {
      _isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + _groundCheckPos, _groundCheckRadius, _groundLayer);
   }

   

   #endregion

   #endregion

   #region  Other Methods

   public void GameOver()
   {
      print("Game Over");
      _gameOverManager.GameOverScreen();
   }

   public void DisablePlayerImput()//Methods Disables PlayerInput used from different scripts
   {
      _inputSystemActions.Player.Disable();
   }

   public void EnablePlayerImput()//Method Enables PlayerInput 
   {
      _inputSystemActions.Player.Enable();
      
   }

   #endregion

   #region Animation Methods

   private void AnimationAction(int state)

   {
      _anim.SetTrigger("ActionTrigger");
      _anim.SetInteger("ActionId", state);
   }

   #endregion

   

   #region Gizmos

   private void OnDrawGizmos() //Zeichnet GroundCheck
   {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere((Vector2)transform.position + _groundCheckPos, _groundCheckRadius);
   }

   #endregion

   #region Sounds

   void WalkingSound()
      {
         SoundManager.instance.PlayRandomSound(_stepSound, transform, 0.6f);// Spielt zufälligen Schritt Sound
      }
   
   private IEnumerator PlaySoundsRepeated() //von Nikodem, statt Nutzung von Invoke
   {
      while (enabled)
      {
         yield return null;
         if (!_isGrounded || _moveAction.ReadValue<Vector2>() == Vector2.zero) continue;

         yield return new WaitForSeconds(0.32f);
         WalkingSound();
      }
   }

   #endregion
   
}
