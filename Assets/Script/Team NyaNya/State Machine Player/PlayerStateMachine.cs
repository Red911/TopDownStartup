using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerStateMachine : MonoBehaviour
    {
        PlayerController _playerController;

        void Start()
        {
            _playerController = GetComponent<PlayerController>();
        }

        public void SwitchState(PlayerState state)
        {
            //if (playerController.currentState != null) return;

            _playerController.CurrentState.ExitState(_playerController);
            _playerController.CurrentState = state;
            state.EnterState(_playerController);
        }
    }
}
