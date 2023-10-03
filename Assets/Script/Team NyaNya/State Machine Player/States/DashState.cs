using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class DashState : PlayerState
    {
        public override void EnterState(PlayerController player)
        {
            PlayerController = player;

            dashDuration = _mSettings.dashDurationMax;
        }

        public override void UpdateState(PlayerController player)
        {
            Dashing();
        }

        public override void ExitState(PlayerController player)
        {
            if (player.IsMoving) player.Movement.Move(Vector2.zero);
        }

        [System.Serializable]
        public class MovementSettings
        {
            public float dashSpeed = 1000f;
            public float dashDurationMax = 1f;
            public float dashCDMax = 1.5f;
            public int dashChargeMax = 1;
        }
        public MovementSettings _mSettings;
        float dashDuration;

        void Dashing()
        {
            if (dashDuration > 0) dashDuration = Mathf.Clamp(dashDuration - Time.deltaTime, 0, _mSettings.dashDurationMax);
            else
            {
                PlayerController.StateMachine.SwitchState(PlayerController.NormalState);

                return;
            }
        }
    }
}
