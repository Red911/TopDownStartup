using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class EquipmentSelectPipeline : EquipmentPipeline<IEnumerable<Equipment>>
    {
    public override IEnumerable<Equipment> Process(IEnumerable<Equipment> input)
    {
        foreach (var filter in filters)
        {
            input = filter.Execute(input);
        }

        return input;
    }
   
    }

