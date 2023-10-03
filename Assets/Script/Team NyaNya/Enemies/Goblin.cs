using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Goblin : Mob
    {
        [SerializeField] private CircleCollider2D _attackZone;
        [SerializeField] private AttackSpace _attackSpace;


        private void Update()
        {
            if (_attackSpace.inZone)
            {
                StartCoroutine(AttackCircle());
            }
        }
        

        IEnumerator AttackCircle()
        {
            print("hit");
            _attackZone.enabled = false;
            yield return new WaitForSeconds(2f);
            _attackZone.enabled = true;
        }
        
        
    }
}
