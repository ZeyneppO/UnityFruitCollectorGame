using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public float speed = 10f;
    public GameObject ballPrefab;
    public GameObject[] fruits;
    public bool stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnFruitsRoutine());
        StartCoroutine(SpawnBallRoutine());
    }
    IEnumerator SpawnFruitsRoutine()
    {
        yield return new WaitForSeconds(1f);
        while (stopSpawning == false)
        {
            // Rastgele pozisyon ve meyve için deðiþken atama
            Vector3 posToSpawn = new Vector3(Random.Range(-5.5f, 5.5f), 5.5f, 0);
            int randomFruit = Random.Range(0, fruits.Length); 

            Instantiate(fruits[randomFruit], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator SpawnBallRoutine()
    {
        yield return new WaitForSeconds(5f);
        while (stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-5.5f, 5.5f), 5.5f, 0);
            
            Instantiate(ballPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }

    public void OnPlayerDeath()
    {
        stopSpawning = true;       
    }
}
