using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Skill : ScriptableObject
    {
        public new string name;
        public float cooldownTime;
        public float activeTime;
        
        public virtual void Activate(GameObject parent){}
        public virtual void BeginCooldown(GameObject parent){}
    }
}
