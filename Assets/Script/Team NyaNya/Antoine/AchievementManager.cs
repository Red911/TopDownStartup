using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NaughtyAttributes;
using UnityEngine.UI;
using Game;

public class AchievementManager : MonoBehaviour
    {
    public static List<Achievement> achievements;

    
    [SerializeField] int achievementTotalCount = 0;
    public static int achievementsDone = 0;


    // Juste pour tester
    [SerializeField] int intTest;
    [SerializeField] GameObject gameObjectTest;

    [Header("Fenêtre d'achievement")]
    [SerializeField] Text windowTitleTxt;
    [SerializeField] Text windowDescTxT;
    //---------------
    [Header("Paramètres de l'achievement à ajouter")]
    [SerializeField] bool showParameters;
    [SerializeField, ShowIf("showParameters")] string nameTheAchievement;
    [SerializeField, ShowIf("showParameters")] string describeTheAchievement;
    [SerializeField, ShowIf("showParameters")] int prerequisiteIntToAchieve = 2;

    [Header("Index de l'achievement à supprimer")]
    [SerializeField] int indexToRemove;

    [Button]
    public void AddAchievement()
    {
        achievements.Add(new Achievement(nameTheAchievement, describeTheAchievement, (object o) => intTest >= prerequisiteIntToAchieve ));
        //achievementTotalCount++;
    }
    [Button]
    public void AchievementDone()
    {
        Debug.Log(achievementsDone);
    }

    [Button]
    public void AchievementToRemoveFromId()
    {
        Debug.Log(achievements[indexToRemove].Name + " a été supprimé");
        achievements.RemoveAt(indexToRemove);
    }

    [Button]
    public void AchievementsClear()
    {
        Debug.Log("Achievements cleared");
        achievements.Clear();
    }

    [Button]
            
    public void ReInitializeAchievements()
    {
        achievements.Add(new Achievement("Integer", "le nombre doit être supérieur ou égal à 5", (object o) => intTest >= 5));
        achievements.Add(new Achievement("La bonne couleur !", "La couleur de l'objet doit être bleu foncé", (object o) => gameObjectTest.GetComponent<SpriteRenderer>().color.Equals(Color.blue)));
        achievements.Add(new Achievement("Tueur d'orc", "Vous avez tué 5 orcs", (object o) => StatsOfPlayer.mobKilledInTotal >= 5));
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
        ///
        // Ajout d'achievements
            achievements.Add(new Achievement("Integer", "le nombre doit être supérieur ou égal à 5", (object o) => intTest >= 5));    
            achievements.Add(new Achievement("La bonne couleur !", "La couleur de l'objet doit être bleu foncé", (object o) => gameObjectTest.GetComponent<SpriteRenderer>().color.Equals(Color.blue)));
            achievements.Add(new Achievement("Tueur d'orc", "Vous avez tué 1 orc", (object o) => StatsOfPlayer.mobKilledInTotal >= 1));
            achievements.Add(new Achievement("Chasseur de trésor", "Vous avez ouvert le coffre", (object o) => GameObject.Find("Chest").GetComponent<Chest>().IsOpen1));  
            //'/
        }
  
        private void Update()
        {
            CheckCompletion();
            achievementTotalCount = achievements.Count;
        }

        private void CheckCompletion()
        {
            if (achievements == null)
               return;
        

        foreach (var achievement in achievements)
            {
                achievement.UpdatedCompletion();
            }
        }
}

    public class Achievement
    {
        public Achievement(string name, string description, Predicate<object> required)
        {
            this.title = name;
            this.description = description;
            this.required = required;
       
        }

    [SerializeField] string title;
    [SerializeField] string description;
    [SerializeField] Text txtTitle;
    [SerializeField] Text txtdescription;
    [SerializeField] Predicate<object> required;

    [SerializeField] bool achieved; 
    
    public string Name { get => title; }
    public bool Achieved { get => achieved; }

    

    public void UpdatedCompletion()
        {
            
            if (achieved)
                return;
            if (RequirementsMets())
            {
                
                Debug.Log(title + " : " + description);
                achieved = true;
                AchievementManager.achievementsDone++;               
             }
        }
   

    public bool RequirementsMets()
        {
            
            return required.Invoke(null);
        }
    }


