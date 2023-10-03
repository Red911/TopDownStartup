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

        [SerializeField, BoxGroup("States")] NormalState _normalState;
        [SerializeField, BoxGroup("States")] DashState _dashState;


        bool inputMoving;
        public bool InputMoving { get => inputMoving; set => inputMoving = value; }

        #endregion

        private void Start()
        {
            currentState = NormalState;
            currentState.EnterState(this);
        }

        private void FixedUpdate()
        {
            currentState.UpdateState(this);
        }
    }
}
