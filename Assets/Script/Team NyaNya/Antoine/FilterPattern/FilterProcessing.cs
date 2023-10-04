using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class FilterProcessing : MonoBehaviour
{
    [Button]
    public void Filter()
    {
        var equipmentType = EquipmentRepository.EquipmentList;

        EquipmentSelectPipeline equipSelectPipeline = new EquipmentSelectPipeline();

        equipSelectPipeline.Register(new TypeOfEquipmentFilter())
            .Register(new StatusOfEquipmentFilter())
            .Register(new AtkPointOfEquipmentFilter());

        var equipmentTypeProcessing = equipSelectPipeline.Process(equipmentType);
        for (int i = 0; i < equipmentType.Count; i++)
        {
            if (equipmentType[i].EquipmentType == "melee")
                Debug.Log(equipmentType[i].EquipmentName);
        }
    }
}

public class TypeOfEquipmentFilter : IFilter<IEnumerable<Equipment>>
{
    public IEnumerable<Equipment> Execute(IEnumerable<Equipment> input)
    {
        if (input == null || input.Count() < 1)
        {
            return input;
        }
        return input.Where(equipment => equipment.EquipmentType == "melee");
    }
}

public class StatusOfEquipmentFilter : IFilter<IEnumerable<Equipment>>
{
    public IEnumerable<Equipment> Execute(IEnumerable<Equipment> input)
    {
        if (input == null || input.Count() < 1)
        {
            return input;
        }
        return input.Where(equipment => equipment.EquipmentStatus == "neuf");
    }
}

public class AtkPointOfEquipmentFilter : IFilter<IEnumerable<Equipment>>
{
    public IEnumerable<Equipment> Execute(IEnumerable<Equipment> input)
    {
        if (input == null || input.Count() < 1)
        {
            return input;
        }
        return input.Where(equipment => equipment.AtkStat >= 50);
    }
}
