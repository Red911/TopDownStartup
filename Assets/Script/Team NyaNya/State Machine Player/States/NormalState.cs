using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class NormalState : PlayerState
    {
        public override void EnterState(PlayerController player)
        {
            PlayerController = player;
            player.Movement.CanMove = true;
        }

        public override void UpdateState(PlayerController player)
        {
            
        }

        public override void ExitState(PlayerController player)
        {
            player.Movement.CanMove = false;
        }

        [System.Serializable]
        protected class MovementSettings
        {
            [SerializeField] float moveSpeed = 8f;
            [SerializeField] float dx = 10f;

            [SerializeField] float rotationSpeed = 800f;

            [SerializeField] float turnSmoothTime = 0.1f;
            [SerializeField] float turnSmoothVelocity;
        }
        protected MovementSettings mSettings;



        public Vector3 moveDir;
        Vector3 theMove;
    }
}
