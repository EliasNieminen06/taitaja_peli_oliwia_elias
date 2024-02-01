using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoint;
    [SerializeField] GameObject enemy;
    bool canSpawn = true;
    float spawnDelay = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(spawn());
        }
    }

    IEnumerator spawn()
    {
        canSpawn = false;
        int currentSpawnPoint = Random.Range(0, spawnPoint.Length);
        Instantiate(enemy, spawnPoint[currentSpawnPoint].position, Quaternion.identity);

        yield return new WaitForSeconds(spawnDelay);

        canSpawn = true;
    }
}
