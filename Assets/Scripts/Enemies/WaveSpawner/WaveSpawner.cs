using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private readonly float _timeBetweenWaves = 5f;
    private float _countdown = 2f;

    void Update()
    {
        if(_countdown <= 0f)
        {
            SpawnWave();
            _countdown = _timeBetweenWaves;
        }
        _countdown -= Time.deltaTime;
    }

    private void SpawnWave()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
