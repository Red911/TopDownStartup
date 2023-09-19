using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TU_Challenge
{
    public class MyMathImplementation
    {
        internal static int Add(int a, int b)
        {
            return a+b;
        }

        internal static List<int> GenericSort(List<int> toSort, Func<int, int, bool> isInOrder)
        {
            Sort(toSort);
            for (int i = 0; i < toSort.Count; i++)
            {
                
                Debug.Log("List : "+ i + " : " + toSort[i]);
            }

            return toSort;
        }

        internal static List<int> GetAllPrimary(int a)
        {
            throw new NotImplementedException();
        }

        internal static bool IsDivisible(int a, int b)
        {
            throw new NotImplementedException();
        }

        internal static bool IsEven(int a)
        {
            throw new NotImplementedException();
        }

        internal static bool IsInOrder(int a, int b)
        {
            if (a < b) 
                return true;
            else
            {
                return false; 
            }
        }

        internal static bool IsInOrderDesc(int arg1, int arg2)
        {
            if (arg1 > arg2) 
                return true;
            else
            {
                return false; 
            }
        }

        internal static bool IsListInOrder(List<int> list)
        {
            throw new NotImplementedException();
        }

        internal static bool IsMajeur(int age)
        {
            if (age < 0) throw new ArgumentException();
            if (age >= 150) throw new ArgumentException();
            
            return age >= 18;
        }

        internal static bool IsPrimary(int a)
        {
            throw new NotImplementedException();
        }

        internal static int Power(int a, int b)
        {
            throw new NotImplementedException();
        }

        internal static int Power2(int a)
        {
            throw new NotImplementedException();
        }

        internal static List<int> Sort(List<int> toSort)
        {
            for (int i = 0; i < toSort.Count - 1; i++)
            {
                for (int j = 0; j < toSort.Count - 1; j++)
                {
                    if (IsInOrder(toSort[j + 1], toSort[j]))
                    {
                        int swapper;
                    
                        swapper = toSort[j];
                    
                        toSort[j] = toSort[j + 1];
                    
                        toSort[j + 1] = swapper;
                   
                    }
                }
                
            }

            return toSort;
        }
    }
}
