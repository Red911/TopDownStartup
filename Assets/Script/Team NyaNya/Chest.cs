using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class Chest : MonoBehaviour, IInteractable
    {

        private bool _isOpen;
        [SerializeField] private GameObject player;
        public float radiusDetection = 5.0f;
        [SerializeField] private Animator _animator;
        private int IsOpen = Animator.StringToHash("IsOpen");
        [SerializeField]private GameObject message;

        public bool IsOpen1 { get => _isOpen; }

        private void Update()
        {
            if (CanInteract() && CheckPlayer())
            {
                message.SetActive(true);
                if (Keyboard.current.eKey.isPressed)
                {
                    Interact();
                }
            }
            else
                message.SetActive(false);  
            
        }

        public void Interact()
        {
            _isOpen = true;
            _animator.SetBool(IsOpen, _isOpen);
            print("20 pesos bro");
            
        }

        public bool CanInteract()
        {
            return !_isOpen;
        }

        public bool CheckPlayer()
        {
            var col = Physics2D.OverlapCircleAll(transform.position, radiusDetection);
            for (int i = 0; i < col.Length; i++)
            {
                if (col[i].gameObject == player)
                {
                    
                    return true;
                }
            }
            return false;
        }
        
        public void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            
            Gizmos.DrawWireSphere(transform.position, radiusDetection);
        }
        
        
        
    }
}
