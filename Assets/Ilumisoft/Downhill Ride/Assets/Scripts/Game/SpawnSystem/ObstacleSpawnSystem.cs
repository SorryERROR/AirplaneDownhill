using System.Collections.Generic;
using UnityEngine;

namespace ADH.Game
{
    public class ObstacleSpawnSystem : SpawnSystem
    {
        [SerializeField] private List<GameObject> prefab = null;
        [SerializeField] private GameObject ADHprefabCoin = null;

        [SerializeField] private int poolSize = 20;

        //The pool holding all spawnable objects
        private GameObject[] _pool;

        //The index of the next object spawned
        private int _index;

        private void Awake()
        {
            _pool = new GameObject[poolSize];

            for (var i = 0; i < poolSize - 1; i++)
            {
                var rand = Random.Range(0, 100);
                
                if (rand > 25)
                {
                    var instance = Instantiate(prefab[Random.Range(0, prefab.Count)]);
                    instance.SetActive(false);
                    _pool[i] = instance;
                    continue;
                }
                
                var adhCoin = Instantiate(ADHprefabCoin);
                adhCoin.SetActive(false);
                _pool[i] = adhCoin;
            }

            _index = 0;
        }

        public override void ADHSpawn(Vector3 position)
        {
            UpdatePoolIndex();
            
            var adh = _pool[_index];
            
            if (adh == null)
                return;

            adh.transform.position = position;

            adh.SetActive(true);
        }

        private void UpdatePoolIndex()
        {
            _index++;

            if (_index >= _pool.Length)
            {
                _index = 0;
            }
        }
    }
}