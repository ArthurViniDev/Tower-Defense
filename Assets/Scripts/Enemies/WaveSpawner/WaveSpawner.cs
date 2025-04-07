using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private readonly float _timeBetweenWaves = 5f;
    private float _countdown = 2f;

    private int _waveEnemyCount = 1;

    void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = _timeBetweenWaves;
        }
        _countdown -= Time.deltaTime;
    }

    private IEnumerator SpawnWave()
    {
        int currentEnemiesSpawned = 0;
        while (_waveEnemyCount > currentEnemiesSpawned)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            currentEnemiesSpawned++;
        }
        _waveEnemyCount++;
    }
}
