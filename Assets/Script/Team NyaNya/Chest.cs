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

        public bool IsOpen1 { get => _isOpen; }

        private void Update()
        {
            if (Keyboard.current.eKey.isPressed && CanInteract() && CheckPlayer())
            {
                Interact();
            }
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
                    print("player here");
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
