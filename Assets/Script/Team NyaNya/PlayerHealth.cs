using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health = 100;
        [SerializeField] private Slider healthBar;
        [SerializeField] private ParticleSystem blood;
        
        private int Health { get => health; set => health = value; }

        private void Start()
        {
            healthBar.value = Health;
        }

        public void Damage(int amount)
        {
            Health -= amount;
            healthBar.value = Health;
            Instantiate(blood, transform.position, Quaternion.identity);
            if (Health <= 0)
            {
                Kill();
            }
        }

        public void Kill()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
