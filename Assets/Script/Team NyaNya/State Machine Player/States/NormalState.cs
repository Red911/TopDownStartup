using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class NormalState : PlayerState
    {
        #region Movement Settings
        protected float moveSpeed;
        protected float dx;

        protected float rotationSpeed;

        protected float turnSmoothTime;
        protected float turnSmoothVelocity;
        #endregion

        Vector2 theMove;

        public override void EnterState(PlayerController player)
        {
            PlayerController = player;
            player.Movement.CanMove = true;
        }

        public override void UpdateState(PlayerController player)
        {
            if (player.IsMoving)
            {
                theMove = player.Move.normalized * moveSpeed * Time.fixedDeltaTime;
            }
            else if (theMove != Vector2.zero)
            {
                theMove = Vector2.MoveTowards(theMove, Vector2.zero, dx);
            }

            player.Movement.Move(theMove);
        }

        public override void ExitState(PlayerController player)
        {
            player.Movement.CanMove = false;
        }



    }
}
