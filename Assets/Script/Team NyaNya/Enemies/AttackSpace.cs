using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AttackSpace : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [HideInInspector] public bool inZone;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == player) inZone = true;
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == player) inZone = false;
        }
    }
}
