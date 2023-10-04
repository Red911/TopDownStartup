using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health = 100;
        private int Health { get; set; }

        public void Damage(int amount)
        {
            Health -= amount;
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
