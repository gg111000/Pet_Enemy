using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        float secondsBetweenSpawn = 2;
        StartCoroutine(DelayTime(secondsBetweenSpawn));
    }

    private IEnumerator DelayTime(float delay)
    {
        var wait = new WaitForSeconds(delay);
        
        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
        Rigidbody2D copy = Instantiate(_enemyPrefab, _spawnPoints[spawnPointNumber].position, Quaternion.identity);
    }
}
