using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitAsteroid : MonoBehaviour
{
    // this sets up the variables to release a number of enemies on a cooldown timer.
    public GameManager instance;
    public Transform thisSpawner;

    [SerializeField]
    private GameObject newBody;

    [SerializeField]
    private GameObject prefabA;

    [SerializeField]
    private GameObject prefabB;

    [SerializeField]
    private GameObject prefabC;

    [SerializeField]
    private GameObject prefabD;

    [SerializeField]
    private GameObject prefabE;

    [SerializeField]
    private GameObject prefabF;

    [SerializeField]
    private int spawnCount;

    [SerializeField]
    private float spawnTime;

    [SerializeField]
    private float spawnDelay;

    private int remainingEnemies = 3;

    void Start()
    {
        // this initializes the items used by this game to make it work
        spawnCount = GameManager.instance.spawnCount;
        spawnTime = GameManager.instance.spawnTime;
        spawnDelay = GameManager.instance.spawnDelay;
        prefabA = GameManager.instance.prefabA;
        prefabB = GameManager.instance.prefabB;
        prefabC = GameManager.instance.prefabC;
        prefabD = GameManager.instance.prefabD;
        prefabE = GameManager.instance.prefabE;
        prefabF = GameManager.instance.prefabF;

        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnDelay);

        // Initial wait for the first spawn
        yield return new WaitForSeconds(spawnTime);

        for (int x = spawnCount; x > 0; --x)
        {
            // this uses a random number generator to pick from the list of six options
            int y = UnityEngine.Random.Range(1, 6);
            if (y == 1)
            {
                GameObject newBody = Instantiate(prefabA, transform.position, transform.rotation);
            }
            if (y == 2)
            {
                GameObject newBody = Instantiate(prefabB, transform.position, transform.rotation);
            }
            if (y == 3)
            {
                GameObject newBody = Instantiate(prefabC, transform.position, transform.rotation);
            }
            if (y == 4)
            {
                GameObject newBody = Instantiate(prefabD, transform.position, transform.rotation);
            }
            if (y == 5)
            {
                GameObject newBody = Instantiate(prefabE, transform.position, transform.rotation);
            }
            if (y == 6)
            {
                GameObject newBody = Instantiate(prefabF, transform.position, transform.rotation);
            }
            if (y <= 0 | y > 6)
            {
                GameObject newBody = Instantiate(prefabA, transform.position, transform.rotation);
            }

            // Detect when an enemy gets destroyed, emitter mechanics, I will admit I am new to realtime applications
            // this adds an emitter to the items spawned to allow a listen event for destruction
            DestroyEventEmitter destroyEventEmitter = newBody.AddComponent<DestroyEventEmitter>();
            destroyEventEmitter.OnObjectDestroyedEvent += OnGameObjectDestroyed;
            remainingEnemies++;

            // Wait before next spawn prior to spawning again
            yield return wait;
        }

    }

    private void OnGameObjectDestroyed(DestroyEventEmitter emitter)
    {
        remainingEnemies--;
        emitter.OnObjectDestroyedEvent -= OnGameObjectDestroyed;

        if (remainingEnemies <= 0)
        {
            remainingEnemies = 3;
            SpawnObjects();
        }

    }
}
