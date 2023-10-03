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
    }
}
