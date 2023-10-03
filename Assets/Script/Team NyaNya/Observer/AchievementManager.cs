using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Assertions.Must;
using NaughtyAttributes;

public class AchievementManager : MonoBehaviour
    {
    public static List<Achievement> achievements;

    [SerializeField] int achievementTotalCount = 0;
    public static int achievementsDone = 0;

    // Juste pour tester
    [SerializeField] int intTest;
    [SerializeField] GameObject gameObjectTest;
    //---------------
    [Header("Paramètres de l'achievement")]
    [SerializeField] bool showParameters;
    [SerializeField, ShowIf("showParameters")] string nameTheAchievement;
    [SerializeField, ShowIf("showParameters")] string describeTheAchievement;
    [SerializeField, ShowIf("showParameters")] int prerequisiteIntToAchieve = 2;
    [Button]
    public void AddAchievement()
    {
        achievements.Add(new Achievement(nameTheAchievement, describeTheAchievement, (object o) => intTest >= prerequisiteIntToAchieve ));
        achievementTotalCount++;
    }
    [Button]
    public void AchievementDone()
    {
        Debug.Log(achievementsDone);
    }
    public bool AchievementUnlocked(string achievementName)
        {
            bool result = false;

            if (achievements == null)
                return false;

            Achievement[] achievementsArray = achievements.ToArray();
            Achievement a = Array.Find(achievementsArray, ach => achievementName == ach.Name);

            if(a == null)
                return false;

            result = a.Achieved;

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
            achievements.Add(new Achievement("La bonne couleur !", "La couleur de l'objet doit être bleu foncé", (object o) => gameObjectTest.GetComponent<SpriteRenderer>().color.Equals(Color.blue)));

            for(int i = 0; i < achievements.Count; i++) 
            {
                achievementTotalCount++;
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
        

        foreach (var achievement in achievements)
            {
                achievement.Completion();              
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

    [SerializeField] string name;
    [SerializeField] string description;
    [SerializeField] Predicate<object> required;

    [SerializeField] bool achieved;

    public string Name { get => name; }
    public bool Achieved { get => achieved; }

    public void Completion()
        {
            if (achieved)
                return;
            if (RequirementsMets())
            {
                Debug.Log(name + " : " + description);
                achieved = true;
                AchievementManager.achievementsDone++;               
             }
        }

        public bool RequirementsMets()
        {
            return required.Invoke(null);
        }
    }


