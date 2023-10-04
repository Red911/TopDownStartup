using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EndMessage : MonoBehaviour
    {
        [SerializeField]private GameObject message;
        private void OnTriggerEnter2D(Collider2D other)
        {
            message.SetActive(true);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            message.SetActive(false);
        }
    }
}
