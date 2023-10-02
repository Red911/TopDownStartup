using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface IInteractable
    {
        void Interact();
        bool CanInteract();
        bool CheckPlayer();
    }
}
