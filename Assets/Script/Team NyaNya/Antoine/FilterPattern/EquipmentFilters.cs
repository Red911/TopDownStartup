using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EquipmentFilters : MonoBehaviour
{
    [SerializeField] bool show;
    [SerializeField, ShowIf("show")] string typeFilter;
    [SerializeField, ShowIf("show")] string statusFilter;
    [SerializeField, ShowIf("show")] int atkFilter;
    [SerializeField, ShowIf("show")] int defFilter;
    [Button]
     public void TypeFilter()
    {
        var equipmentType = EquipmentRepository.EquipmentList;
        if (typeFilter != "melee" && typeFilter != "distance" && typeFilter != "magique")
        {
            Debug.Log("Mauvais type d�clar�, pas de filtre possible");
            return;
        }

        for (int i = 0; i < equipmentType.Count; i++)
        {
            if(equipmentType[i].EquipmentType == typeFilter)
                Debug.Log(equipmentType[i].EquipmentName + " est un �quipement " + typeFilter);
        }
    }

    [Button]
    public void StatusFilter()
    {
        var equipmentType = EquipmentRepository.EquipmentList;
        if (statusFilter != "neuf" && statusFilter != "us�" && statusFilter != "cass�")
        {
            Debug.Log("Mauvais statut d�clar�, pas de filtre possible");
            return;
        }

        for (int i = 0; i < equipmentType.Count; i++)
        {
            if (equipmentType[i].EquipmentStatus == statusFilter)
                Debug.Log(equipmentType[i].EquipmentName + " est un �quipement " + statusFilter);
        }
    }

    [Button]
    public void AtkFilter()
    {
        var equipmentType = EquipmentRepository.EquipmentList;

        for (int i = 0; i < equipmentType.Count; i++)
        {
            if (equipmentType[i].AtkStat >= atkFilter)
                Debug.Log(equipmentType[i].EquipmentName + " octroie " + equipmentType[i].AtkStat + " d'attaque");
            else
                Debug.Log("Pas d'�quipement octroyant autant d'attaque");
        }
    }

    [Button]
    public void DefFilter()
    {
        var equipmentType = EquipmentRepository.EquipmentList;

        for (int i = 0; i < equipmentType.Count; i++)
        {
            if (equipmentType[i].DefStat >= defFilter)
                Debug.Log(equipmentType[i].EquipmentName + " octroie " + equipmentType[i].DefStat + " de d�fense");
            else
                Debug.Log("Pas d'�quipement octroyant autant de d�fense");
        }
    }
}


