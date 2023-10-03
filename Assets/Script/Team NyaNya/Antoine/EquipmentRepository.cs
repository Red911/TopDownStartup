using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class EquipmentRepository : MonoBehaviour
    {
    public List<Equipment> EquipmentList;
    [Header("Nombre d'�quipements")]
    [SerializeField] int listCount;

    [Header("Param�tres des �quipements")]
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
            Debug.Log("Mauvais type d�clar�");
            return;
        }
        if (statusOfEquip != "neuf" && statusOfEquip != "us�" && statusOfEquip != "cass�")
        { 
            Debug.Log("Mauvais status d�clar�");
            return;
        }
        EquipmentList.Add(new Equipment(idOfEquip, nameOfEquip, typeOfEquip, statusOfEquip, atkOfEquip, defOfEquip));
        Debug.Log(nameOfEquip + " : ajout�");
    }

    [Header("Index du nom de l'�quipement � voir")]
    [SerializeField] int index;

    

    [Button]
    public void ShowNameOfEquipment()
    {
        if(index > listCount)
        {
            Debug.Log("Il n'y a pas d'�quipement � cet endroit");
            return;
        }
        Debug.Log(EquipmentList[index].EquipmentName);
    }

    private void Start()
    {
        EquipmentList = new List<Equipment>();
        EquipmentList.Add(new Equipment("00", "�p�e", "melee", "neuf", 100, 10));
        EquipmentList.Add(new Equipment("01", "bouclier", "melee", "neuf", 15, 100));
        EquipmentList.Add(new Equipment("02", "arc", "distance", "us�", 35, 0));
        EquipmentList.Add(new Equipment("03", "baton", "magique", "cass�", 5, 0));
    }

    private void Update()
    {
        listCount = EquipmentList.Count;
    }
}

