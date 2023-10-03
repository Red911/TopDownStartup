using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public interface IFilter<T>
    {
        T Execute(T input);
    }

