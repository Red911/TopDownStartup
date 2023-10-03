using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class WalkState : NormalState
    {
        
        [SerializeField] MovementSettings walkSettings;

        private void Start()
        {
            mSettings = walkSettings;
        }
    }
}
