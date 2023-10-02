using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class InteractableDetector : MonoBehaviour
    {
        private List<IInteractable> _interactablesInRange = new List<IInteractable>();
        
        // Update is called once per frame
        void Update()
        {
            print(_interactablesInRange.Count);
            if (Keyboard.current.eKey.isPressed && _interactablesInRange.Count > 0)
            {
                print("aled");
                var interactable = _interactablesInRange[0];
                interactable.Interact();
                if (!interactable.CanInteract())
                {
                    _interactablesInRange.Remove(interactable);
                }
            }

            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.TryGetComponent(out IInteractable interactable))
            {
                if (interactable != null && interactable.CanInteract())
                {
                    _interactablesInRange.Add(interactable);
                    print("aled3");
                }
            }
            
            
                
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            var interactable = other.GetComponent<IInteractable>();
           
            if (_interactablesInRange.Contains(interactable))
            {
                _interactablesInRange.Remove(interactable);
            }
        }
    }
}
