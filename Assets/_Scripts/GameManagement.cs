using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;
public class GameManagement : MonoBehaviour
{
    public List<GameObject> Spawnpoints;
    public List<GameObject> Projectiles;
    public GameObject bob;
    private BobController bobController;

    public int routineLoops = 200;
    public float initialSpawnTime = 5.0f;
    private int score = 1;
    public int pointsToIncrease = 50;
    public float timeToDecrease = 0.02f;
    private int timesDecreased = 1;

    public void Start()
    {
        bobController = bob.GetComponent<BobController>();
        StartCoroutine(SpawnCoroutine());
    }

    private GameObject RandomProjectile()
    {
        int randomProjectileIndex = Random.Range(0, Projectiles.Count);
        return Projectiles[randomProjectileIndex];
    }

    private Vector3 RandomSpawnPoint()
    {
        int randomSpawnPointIndex = Random.Range(0, Spawnpoints.Count);
        var randomSpawnPoint = Spawnpoints[randomSpawnPointIndex].transform.position;
        return randomSpawnPoint;
    }

    IEnumerator SpawnCoroutine()
    {
        float currentSpawnTime = initialSpawnTime; // Initialize with the initial spawn time

        for (int i = 0; i < routineLoops; i++)
        {
            Instantiate(RandomProjectile(), RandomSpawnPoint(), Quaternion.identity);

            yield return new WaitForSeconds(currentSpawnTime);

            if (bobController.Highscore > 1)
            {
                score = bobController.Highscore;
            }
            Debug.Log("the score is: " + score
                    + ", the current spawn time is: " + currentSpawnTime
                    + ", the time to decrease is: " + timesDecreased);

            if (score >= (timesDecreased + 1) * pointsToIncrease)
            {
                Debug.Log("Times Decreased: " + timesDecreased);
                timesDecreased++;
                if (currentSpawnTime >= 1.5f)
                {
                    currentSpawnTime -= timeToDecrease;
                }
                timeToDecrease += 0.02f;
            }
        }
    }
}
