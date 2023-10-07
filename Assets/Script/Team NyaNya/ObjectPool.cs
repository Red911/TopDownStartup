using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ObjectPool : MonoBehaviour
    {
        static ObjectPool instance;
        List<GameObject> pooledObjects;
        [SerializeField] GameObject objectToPool;
        [SerializeField] int amountToPool;

        public static ObjectPool Instance { get { return instance; } }
        public List<GameObject> PooledObjects { get => pooledObjects; set => pooledObjects = value; }
        public GameObject ObjectToPool { get => objectToPool; set => objectToPool = value; }
        public int AmountToPool { get => amountToPool; set => amountToPool = value; }

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            pooledObjects = new List<GameObject>();
            GameObject tmp;
            for (int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }

        public GameObject GetPoolObject()
        {
            for(int i = 0;i < amountToPool; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            return null;
        }
    }
}
