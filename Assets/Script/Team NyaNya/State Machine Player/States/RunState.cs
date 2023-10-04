using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RunState : NormalState
    {
        [SerializeField, BoxGroup("Movement Settings")] float _runSpeed = 800f;

        public override void EnterState(PlayerController player)
        {
            base.EnterState(player);
            moveSpeed = _runSpeed;
        }
    }
}
