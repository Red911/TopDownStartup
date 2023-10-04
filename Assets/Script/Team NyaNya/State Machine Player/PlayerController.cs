using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField, BoxGroup("Dependencies")] EntityMovement _movement;
        [SerializeField, BoxGroup("Dependencies")] Transform _spriteTransform;
        public Transform SpriteTransform { get => _spriteTransform; set => _spriteTransform = value; }

        #region States
        [SerializeField, BoxGroup("Dependencies")] PlayerStateMachine _stateMachine;

        PlayerState currentState;
        public PlayerState CurrentState { get => currentState; set => currentState = value; }
        public EntityMovement Movement { get => _movement; set => _movement = value; }
        public PlayerStateMachine StateMachine { get => _stateMachine; set => _stateMachine = value; }
        public NormalState NormalState { get => _normalState; set => _normalState = value; }
        public DashState DashState { get => _dashState; set => _dashState = value; }
        public WalkState WalkState { get => _walkState; set => _walkState = value; }
        public RunState RunState { get => _runState; set => _runState = value; }

        [SerializeField, BoxGroup("States")] NormalState _normalState;
        [SerializeField, BoxGroup("States")] DashState _dashState;
        [SerializeField, BoxGroup("States")] WalkState _walkState;
        [SerializeField, BoxGroup("States")] RunState _runState;

        #endregion

        bool isMoving;
        public bool IsMoving { get => isMoving; set => isMoving = value; }
        Vector2 move;
        public Vector2 Move { get => move; set => move = value; }

        Vector2 moveDir { get; set; }

        bool canDash;
        float dashCD;
        [SerializeField] float dashCDMax;
        public bool CanDash { get => canDash; set => canDash = value; }
        public float DashCD { get => dashCD; set => dashCD = value; }
        public float DashCDMax { get => dashCDMax; set => dashCDMax = value; }

        bool facingRight;

        private void Start()
        {
            currentState = WalkState;
            currentState.EnterState(this);

            canDash = true;
            facingRight = true;
        }

        private void FixedUpdate()
        {
            currentState.UpdateState(this);

            if (dashCD > 0) dashCD = Mathf.Clamp(dashCD - Time.deltaTime, 0, dashCDMax);
            else if (!canDash) canDash = true;

            if (move.x > 0 && !facingRight || move.x < 0 && facingRight) Flip();
        }

        public void SetMoveDir(Vector2 mDir) => moveDir = mDir;

        void Flip()
        {
            facingRight = !facingRight;

            _spriteTransform.Rotate(0f, 180f, 0f);
        }
    }
}
