using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class DashState : PlayerState
    {
        #region MovementSettings

        [SerializeField, BoxGroup("Movement Settings")] float dashSpeed = 1000f;
        [SerializeField, BoxGroup("Movement Settings")] float dashDurationMax = 1f;
        //[SerializeField, BoxGroup("Movement Settings")] float dashCDMax = 1.5f;
        #endregion

        [SerializeField, Foldout("Event")] UnityEvent _onStartDashing;
        [SerializeField, Foldout("Event")] UnityEvent _onStopDashing;
        public event UnityAction OnStartDashing { add => _onStartDashing.AddListener(value); remove => _onStartDashing.RemoveListener(value); }
        public event UnityAction OnStopDashing { add => _onStopDashing.AddListener(value); remove => _onStopDashing.RemoveListener(value); }

        float dashDuration;
        Vector2 dashDir;


        public override void EnterState(PlayerController player)
        {
            PlayerController = player;

            _onStartDashing.Invoke();

            dashDuration = dashDurationMax;
            player.DashCD = player.DashCDMax;

            dashDir = player.Move.normalized;

            Physics2D.IgnoreLayerCollision(6, 7, true);
        }

        public override void UpdateState(PlayerController player)
        {
            if (dashDuration > 0) dashDuration = Mathf.Clamp(dashDuration - Time.deltaTime, 0, dashDurationMax);
            else
            {
                PlayerController.StateMachine.SwitchState(PlayerController.WalkState);

                return;
            }
            if (dashDir == Vector2.zero) dashDir = Vector2.right;
            player.Movement.Move(dashDir * dashSpeed * Time.fixedDeltaTime);
        }

        public override void ExitState(PlayerController player)
        {
            //if (!player.IsMoving) player.Movement.Move(Vector2.zero);
            _onStopDashing.Invoke();
            player.CanDash = false;
            player.IsMoving = true;
            Physics2D.IgnoreLayerCollision(6, 7, false);
        }

        
    }
}
