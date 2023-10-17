using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable {
    [field: SerializeField, Min(0f)] public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Rigidbody2D GB { get; set; }
    public bool IsFacingRight { get; set; } = true;

    public bool IsAggroed { get; set; }
    public bool IsWithinStrikingDistance { get; set; }

    #region State Machine Variables

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyIdleState IdleState { get; set; }
    public EnemyChaseState ChaseSate { get; set; }
    public EnemyAttackSate AttackState { get; set; }

    #endregion

    #region Idle Variables

    public Rigidbody2D BulletPrefab;
    public float RandomMovementRange = 5f;
    public float RandomMovementSpeed = 1f;

    #endregion

    private void Awake() {
        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine);
        ChaseSate = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackSate(this, StateMachine);
    }

    private void Start() {
        CurrentHealth = MaxHealth;

        GB = GetComponent<Rigidbody2D>();

        StateMachine.Initialize(IdleState);
    }

    private void Update() {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    #region Health / Die Functions

    public void Damage(float damageAmount) {
        CurrentHealth -= damageAmount;

        if (CurrentHealth <= 0f) {
            Die();
        }
    }

    public void Die() {

    }

    #endregion

    #region Movement Functions

    public void MoveEnemy(Vector2 velocity) {
        GB.velocity = velocity;
        CheckForLeftOrRightFacing(velocity);
    }

    public void CheckForLeftOrRightFacing(Vector2 velocity) {
        if (IsFacingRight && velocity.x < 0f) {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }

        else if (!IsFacingRight && velocity.y > 0f) {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }

    #endregion

    #region Distance Checks

    public void SetAggroStatus(bool isAggroed) {
        IsAggroed = isAggroed;
    }

    public void SetStrikingDistanceBool(bool isWithinStrkingDistance) {
        IsWithinStrikingDistance = isWithinStrkingDistance;
    }

    #endregion

    #region Animation Triggers

    public void AnimationTriggerEvent(AnimationTriggerType triggerType) {
        //TODO: fill in once Satemachine is created
        StateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerType {
        EnemyDamaged,
        PlayFootStepSound
    }

    #endregion
}
