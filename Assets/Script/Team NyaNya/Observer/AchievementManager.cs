using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Assertions.Must;


    public class AchievementManager : MonoBehaviour
    {
        public static List<Achievement> achievements;

        public int achievementCount = 0;

        // Juste pour tester
        public int intTest;
       // public GameObject gameObjectTest;

        public bool AchievementUnlocked(string achievementName)
        {
            bool result = false;

            if (achievements == null)
                return false;

            Achievement[] achievementsArray = achievements.ToArray();
            Achievement a = Array.Find(achievementsArray, ach => achievementName == ach.name);

            if(a == null)
                return false;

            result = a.achieved;

            return result;
        }

        private void Start()
        {
            InitializeAchievement();
        }

        private void InitializeAchievement()
        {
            if (achievements != null)
                return;

            achievements = new List<Achievement>();
            achievements.Add(new Achievement("Integer", "le nombre doit être supérieur ou égal à 5", (object o) => intTest >= 5));    
          //  achievements.Add(new Achievement("La bonne couleur !", "La couleur de l'objet doit être rouge", (object o) => gameObjectTest.GetComponent<SpriteRenderer>().color.Equals(Color.blue)));

            for(int i = 0; i < achievements.Count; i++) 
            {
                achievementCount++;
            }
        }

        private void Update()
        {
            CheckCompletion();

        }

        private void CheckCompletion()
        {
            if (achievements == null)
                return;

            foreach(var achievement in achievements)
            {
                achievement.UpdateCompletion();
            }
        }
    }

    public class Achievement
    {
        public Achievement(string name, string description, Predicate<object> required)
        {
            this.name = name;
            this.description = description;
            this.required = required;
       
        }

        public string name;
        public string description;
        public Predicate<object> required;

        public bool achieved;

        public void UpdateCompletion()
        {
            if (achieved)
                return;
            if (RequirementsMets())
            {
                Debug.Log($"{name}: {description}");
                achieved = true;
            }
        }

        public bool RequirementsMets()
        {
            return required.Invoke(null);
        }
    }


