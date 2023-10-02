using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
    public class AchievementManager : MonoBehaviour
    {
        
    }

    public class Achievement
    {
        public Achievement(string title, string description, Predicate<object> requirement)
        {
            this.title = title;
            this.description = description;
            this.requirement = requirement;

            
        }

        [SerializeField] string title;
        [SerializeField] string description;
        [SerializeField] Predicate<object> requirement;
        [SerializeField] bool achieved;

        public void UpdateCompletion()
        {
            if (achieved)
                return;
            if (RequirementsMets())
            {
                achieved = true;
            }
        }

        private bool RequirementsMets()
        {
            throw new NotImplementedException();
        }
    }

    
}
