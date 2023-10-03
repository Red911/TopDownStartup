using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class EquipmentRepository : MonoBehaviour
    {
    public List<Equipment> EquipmentList;
    [Header("Nombre d'équipements")]
    [SerializeField] int listCount;

    [Header("Paramètres des équipements")]
    [SerializeField] bool showEqupParam;
    [SerializeField, ShowIf("showEqupParam")] string idOfEquip;
    [SerializeField, ShowIf("showEqupParam")] string nameOfEquip;
    [SerializeField, ShowIf("showEqupParam")] string typeOfEquip;
    [SerializeField, ShowIf("showEqupParam")] string statusOfEquip;
    [SerializeField, ShowIf("showEqupParam")] int atkOfEquip;
    [SerializeField, ShowIf("showEqupParam")] int defOfEquip;
    

    [Button]
    public void AddEquipment()
    {
        if (typeOfEquip != "melee" && typeOfEquip != "distance" && typeOfEquip != "magique")
        {
            Debug.Log("Mauvais type déclaré");
            return;
        }
        if (statusOfEquip != "neuf" && statusOfEquip != "usé" && statusOfEquip != "cassé")
        { 
            Debug.Log("Mauvais status déclaré");
            return;
        }
        EquipmentList.Add(new Equipment(idOfEquip, nameOfEquip, typeOfEquip, statusOfEquip, atkOfEquip, defOfEquip));
        Debug.Log(nameOfEquip + " : ajouté");
    }

    [Header("Index du nom de l'équipement à voir")]
    [SerializeField] int index;

    

    [Button]
    public void ShowNameOfEquipment()
    {
        if(index > listCount)
        {
            Debug.Log("Il n'y a pas d'équipement à cet endroit");
            return;
        }
        Debug.Log(EquipmentList[index].EquipmentName);
    }

    private void Start()
    {
        EquipmentList = new List<Equipment>();
        EquipmentList.Add(new Equipment("00", "épée", "melee", "neuf", 100, 10));
        EquipmentList.Add(new Equipment("01", "bouclier", "melee", "neuf", 15, 100));
        EquipmentList.Add(new Equipment("02", "arc", "distance", "usé", 35, 0));
        EquipmentList.Add(new Equipment("03", "baton", "magique", "cassé", 5, 0));
    }

    private void Update()
    {
        listCount = EquipmentList.Count;
    }
}

