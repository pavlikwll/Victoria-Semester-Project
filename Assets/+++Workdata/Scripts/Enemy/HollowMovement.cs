using System;
using UnityEngine;
using UnityEngine.Events;


public enum EnemyMovementState{Idle, Move}
public enum EnemyActionState {Idle, Attack}

public class HollowMovement : MonoBehaviour
{
    
    
    #region Variables

    private Animator _animator;
    private Rigidbody2D _rb;
    private float _moveSpeed;
    [SerializeField]private float _facingDirection;
    [SerializeField]private EnemyMovementState _enemyMovementState;
    [SerializeField]private EnemyActionState _enemyActionState;
    [SerializeField]private Vector2 wallCheckStart;
    [SerializeField]private float enemyWallDetection;
    [SerializeField]private LayerMask groundAndWallLayerMask;
    [SerializeField]private HollowAttack hollowAttack;
    [SerializeField]private float enemyAttackRange;
    [SerializeField] private Vector2 ledgeCheckStart;
    [SerializeField] private float ledgeCheckDistance = 1f;
    private float _enemyMovementTimer;
    private float _enemyIdleTime;
    private float _enemyAttackTimer;
    private float _enemyAttackTime;
    

    #endregion
    
    
    
    #region Unity Methods

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _facingDirection = 1;
        _enemyMovementState = EnemyMovementState.Idle;
        _enemyActionState = EnemyActionState.Idle;
        _enemyMovementTimer = 3;
        _enemyIdleTime = 0;
        _moveSpeed = 5;
        _enemyAttackTime = 0;
        _enemyAttackTimer = 3;



    }

    private void FixedUpdate()
    {
        
        
        if (_enemyActionState == EnemyActionState.Idle)
        {
            EnemyIdleBehavior();
        }

        if (_enemyActionState == EnemyActionState.Attack)
        {
            EnemyAttackBehavior();
        }

        MovementValueAnimator();
    }

    #endregion

    #region Methods

    private void EnemyIdleBehavior()
    {
        _enemyIdleTime += Time.deltaTime;

        if (_enemyIdleTime >= _enemyMovementTimer)
        {
            if (_enemyMovementState == EnemyMovementState.Idle)
            {
                _enemyMovementState = EnemyMovementState.Move;
                _enemyIdleTime = 0;
            }
            else
            {
                _enemyMovementState = EnemyMovementState.Idle;
                _enemyIdleTime = 0;
            }
        }

        if (_enemyMovementState == EnemyMovementState.Move)
        {
            bool wallAhead = !RayCastWallCheck();
            bool groundAhead = GroundAheadCheck();

            if (wallAhead || !groundAhead)
            {
                _rb.linearVelocityX = 0;
                Flip();
                return;
            }

            _rb.linearVelocityX = _facingDirection * _moveSpeed;
        }
        else if (_enemyMovementState == EnemyMovementState.Idle)
        {
            _rb.linearVelocityX = 0;
        }
    }

    private void EnemyAttackBehavior()
    {

        if (hollowAttack == null || hollowAttack.attackTarget == null)
        {
            _enemyActionState = EnemyActionState.Idle;
            return;
        }

        Playercontroller player = hollowAttack.attackTarget.GetComponent<Playercontroller>();

        if (player == null)
        {
            _enemyActionState = EnemyActionState.Idle;
            return;
        }

        if (player._starStateAvailable == StarStateAvailable.False)
        {
            hollowAttack.attackTarget = null;
            _enemyActionState = EnemyActionState.Idle;
            return;
        }
            
        _enemyAttackTime += Time.deltaTime;
        
        if ((transform.position.x > hollowAttack.attackTarget.transform.position.x) && (_facingDirection == 1))
        {
            Flip();
        }

        if ((transform.position.x < hollowAttack.attackTarget.transform.position.x) && (_facingDirection == -1))
        {
            Flip();
        }

        bool wallAhead = !RayCastWallCheck();
        bool groundAhead = GroundAheadCheck();

        if (wallAhead || !groundAhead)
        {
            _rb.linearVelocityX = 0;
            Flip();
            return;
        }

        if (Mathf.Abs(transform.position.x - hollowAttack.attackTarget.transform.position.x) >= enemyAttackRange)
        {
            _rb.linearVelocityX = _facingDirection * _moveSpeed;
        }
        else
        {
            _rb.linearVelocityX = 0;
            if (_enemyAttackTime >= _enemyAttackTimer)
                EnemyAttack();
        }
    }

    private void EnemyAttack()
    {
        _animator.SetInteger("ActionId",1);
        _animator.SetTrigger("ActionTrigger");
        _enemyAttackTime = 0;
    }
    
    private void Flip()
    {
        
        transform.rotation = Quaternion.Euler(0, (_facingDirection == 1 ? 180 : 0), 0);
        _facingDirection = (_facingDirection *-1);
      
        
    }

    public void SetActionState()
    {
        if (_enemyActionState == EnemyActionState.Attack)
        {
            _enemyActionState = EnemyActionState.Idle;
        }

        else
        {
            _enemyActionState = EnemyActionState.Attack;
        }
            
    }

    #endregion

    #region Animator

    private void MovementValueAnimator()
    {
        _animator.SetFloat("MovementValue", Math.Abs(_rb.linearVelocityX));
    }

    #endregion

    #region Raycasts

    private bool RayCastWallCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + new Vector2(wallCheckStart.x * _facingDirection, wallCheckStart.y), Vector2.right * _facingDirection, enemyWallDetection, groundAndWallLayerMask);

        return !hit.collider;
    }

    private bool GroundAheadCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast( (Vector2)transform.position + new Vector2(ledgeCheckStart.x * _facingDirection, ledgeCheckStart.y), Vector2.down, ledgeCheckDistance, groundAndWallLayerMask);

        return hit.collider != null;
    }

    #endregion

    #region Gizmos

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine((Vector2)transform.position + new Vector2(wallCheckStart.x * _facingDirection, wallCheckStart.y), (Vector2)transform.position + new Vector2(wallCheckStart.x * _facingDirection, wallCheckStart.y) + Vector2.right * _facingDirection * enemyWallDetection);

        Gizmos.color = Color.green;
        Gizmos.DrawLine((Vector2)transform.position + new Vector2(ledgeCheckStart.x * _facingDirection, ledgeCheckStart.y), (Vector2)transform.position + new Vector2(ledgeCheckStart.x * _facingDirection, ledgeCheckStart.y) + Vector2.down * ledgeCheckDistance);
    }
    #endregion
}
