using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class WalkState : NormalState
    {

        #region Movement Settings
        [SerializeField, BoxGroup("Movement Settings")] float _walkMoveSpeed = 800f;
        [SerializeField, BoxGroup("Movement Settings")] float _walkDx = 10f;
        #endregion

        public override void EnterState(PlayerController player)
        {
            base.EnterState(player);
            moveSpeed = _walkMoveSpeed;
            dx = _walkDx;
        }
    }
}
