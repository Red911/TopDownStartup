using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public abstract class EquipmentPipeline<T>
    {
        
        protected readonly List<IFilter<T>> filters = new List<IFilter<T>>();

        public EquipmentPipeline<T> Register(IFilter<T> filter)
        {
            filters.Add(filter);
            return this;
        }        
        public abstract T Process(T input);
    }

