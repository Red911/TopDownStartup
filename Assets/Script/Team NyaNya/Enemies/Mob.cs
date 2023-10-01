using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class Mob : MonoBehaviour
    {
        [SerializeField] private int _mobHealth = 10;
        public int MobHealth
        {
            get => _mobHealth;
            set => _mobHealth = value;
        }

        protected virtual void Update()
        {
           
            
        }

        
        
        protected virtual void Attack()
        {
            
        }

        
    }
}
