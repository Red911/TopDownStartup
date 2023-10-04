using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Orc : Mob
    {
        [SerializeField] private GameObject player;
        [SerializeField] private float distanceAttack = 3.0f;
        
        private bool playerIsInRange;
        
        private void Update()
        {
            playerIsInRange = Vector2.Distance(transform.position, player.transform.position) < distanceAttack;

            if (playerIsInRange)
            {
                print("In Range");
               StartCoroutine(CoolDown());
            }
            
        }
        
        protected override void Attack()
        {
            var position = transform.position;
            var hit = Physics2D.Raycast(position, player.transform.position - position, 20);
           
            print(hit.collider.gameObject.name);
            if (hit.collider.gameObject == player)
            {
                print("hitted player");
                player.GetComponentInParent<PlayerHealth>().Damage(20);
            }
        }

        IEnumerator CoolDown()
        {
            var temp = distanceAttack;
            distanceAttack = 0;
            Attack();
            yield return new WaitForSeconds(coolDown);
            distanceAttack = temp;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            
            Gizmos.DrawRay(transform.position, player.transform.position - transform.position);
        }
    }
}
