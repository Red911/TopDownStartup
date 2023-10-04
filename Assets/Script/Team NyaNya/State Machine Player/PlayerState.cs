using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class PlayerState : MonoBehaviour
    {
        private PlayerController playerController;

        public PlayerController PlayerController { get => playerController; set => playerController = value; }

        public abstract void EnterState(PlayerController player);
        public abstract void UpdateState(PlayerController player);
        public abstract void ExitState(PlayerController player);
    }
}
