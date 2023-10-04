using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class Mob : MonoBehaviour, IDamageable
    {
        [SerializeField]protected Rigidbody2D rb;
        [SerializeField] protected MobMove movement;
        [SerializeField] private int _mobHealth = 10;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private int MobHealth
        {
            get => _mobHealth;
            set => _mobHealth = value;
        }

        protected virtual void FixedUpdate()
        {
            if (movement.playerInZone)
            {
                movement.Move();
            }
            
        }

        protected virtual void Attack()
        {
            
        }


        public virtual void Damage(int amount)
        {
            MobHealth -= amount;
        }

        public virtual void Kill()
        {
            print("feur");
            StatsOfPlayer.mobKilledInTotal++;
        }
    }
}
