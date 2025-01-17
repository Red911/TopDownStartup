using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MobMove : MonoBehaviour
    {
        [SerializeField]protected Rigidbody2D rb;
        [SerializeField] private int _mobSpeed = 10;
        [SerializeField]private GameObject player;
        [HideInInspector]public bool playerInZone;
        private int MobSpeed
        {
            get => _mobSpeed * 10;
            set => _mobSpeed = value;
        }
        
        public virtual void Move()
        {
            Vector2 dir = player.transform.position - transform.parent.position;
            dir.Normalize();

            Vector2 move = dir * (MobSpeed * Time.deltaTime);
            rb.velocity = move;
        }
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.gameObject == player)
            {
                playerInZone = true;
            }
        }
        protected void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == player)
            {
                rb.velocity = Vector2.zero;
                playerInZone = false;
            }
        }

        
    }
}
