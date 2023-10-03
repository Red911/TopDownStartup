using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField, BoxGroup("Dependencies")] EntityMovement _movement;
        #region States
        [SerializeField, BoxGroup("Dependencies")] PlayerStateMachine _stateMachine;

        PlayerState currentState;
        public PlayerState CurrentState { get => currentState; set => currentState = value; }
        public EntityMovement Movement { get => _movement; set => _movement = value; }
        public PlayerStateMachine StateMachine { get => _stateMachine; set => _stateMachine = value; }
        public NormalState NormalState { get => _normalState; set => _normalState = value; }
        public DashState DashState { get => _dashState; set => _dashState = value; }
        public WalkState WalkState { get => _walkState; set => _walkState = value; }

        [SerializeField, BoxGroup("States")] NormalState _normalState;
        [SerializeField, BoxGroup("States")] DashState _dashState;
        [SerializeField, BoxGroup("States")] WalkState _walkState;

        #endregion


        bool isMoving;
        public bool IsMoving { get => isMoving; set => isMoving = value; }
        Vector2 move;
        public Vector2 Move { get => move; set => move = value; }

        Vector2 moveDir { get; set; }

        private void Start()
        {
            currentState = WalkState;
            currentState.EnterState(this);
        }

        private void FixedUpdate()
        {
            currentState.UpdateState(this);
        }

        public void SetMoveDir(Vector2 mDir) => moveDir = mDir;
    }
}
