using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private float timeBetweenWaves = 5f;
    private float countdown = 2f;

    void Update()
    {
        if(countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    private void SpawnWave()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
