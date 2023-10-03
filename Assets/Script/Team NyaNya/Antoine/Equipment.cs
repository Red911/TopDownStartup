using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Equipment
    {
        public Equipment(string equipmentId, string name, string type, string status, int atk, int def)
        {
            this.equipmentId = equipmentId;
            this.equipmentName = name;
            this.equipmentType = type;
            this.equipmentStatus = status;
            this.defStat = def;
            this.atkStat = atk;
        }
    [SerializeField] string equipmentId;
    [SerializeField] string equipmentName;
    [SerializeField] string equipmentType;
    [SerializeField] string equipmentStatus;
    [SerializeField] int atkStat;
    [SerializeField] int defStat;

    public string EquipmentId { get => equipmentId; }
    public string EquipmentName { get => equipmentName; }
    public string EquipmentType { get => equipmentType; }
    public string EquipmentStatus { get => equipmentStatus; }
    public int AtkStat { get => atkStat; }
    public int DefStat { get => defStat; }
}



