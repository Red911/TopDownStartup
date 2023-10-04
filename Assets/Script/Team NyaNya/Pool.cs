using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Game
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] GameObject _bullet;
        IObjectPool<GameObject> pool;
        [SerializeField] int _maxPoolSize = 10;
        bool collectionChecks = true;

        public IObjectPool<GameObject> ThePool
        {
            get
            {
                if (pool == null)
                {
                    //pool = new ObjectPool<GameObject>( , OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, _maxPoolSize);
                }
                return pool;
            }
        }

        void OnTakeFromPool(GameObject obj)
        {
            obj?.SetActive(true);
        }

        void OnReturnedToPool(GameObject obj)
        {
            obj?.SetActive(false);
        }

        void OnDestroyPoolObject(GameObject obj)
        {
            Destroy(obj);
        }
    }
}
