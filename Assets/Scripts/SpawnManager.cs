using UnityEngine;

namespace Lab2
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] _enemyPrefabs;
        public GameObject _powerupPrefabs;

        [SerializeField]
        private float _zEnemySpawn, _xSpawnRange, _ySpawnRange, _zPowerupRange;

        [SerializeField]
        private float _startTime, _minDelayTime, _maxDelayTime;

        private void Start()
        {
            InvokeRepeating("SpawnEnemy", _startTime, Random.Range(_minDelayTime, _maxDelayTime));
            InvokeRepeating("SpawnPowerup", _startTime, Random.Range(_minDelayTime, _maxDelayTime));
        }

        private void SpawnEnemy()
        {
            float randomXPos = Random.Range(-_xSpawnRange, _xSpawnRange);
            int indexEnemy = Random.Range(0, _enemyPrefabs.Length);

            Vector3 spawnPos = new Vector3(randomXPos, _ySpawnRange, _zEnemySpawn);

            Instantiate(_enemyPrefabs[indexEnemy], spawnPos, _enemyPrefabs[indexEnemy].transform.rotation);
        }

 
        private void SpawnPowerup()
        {
            float randomXPos = Random.Range(-_xSpawnRange, _xSpawnRange);
            Vector3 spawnPos = new Vector3(randomXPos, _ySpawnRange, _zPowerupRange);

            Instantiate(_powerupPrefabs, spawnPos, _powerupPrefabs.transform.rotation);
        }
    }
}
