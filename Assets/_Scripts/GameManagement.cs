using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManagement : MonoBehaviour
{
    public List<GameObject> Spawnpoints;

    public List<GameObject> Projectiles;

    public int routine = 10;

    public void Start()
    {
        StartCoroutine(SpawnCoroutine());
        //Instantiate(Projectiles[1], Spawnpoints[1].transform.position, Quaternion.identity);
        //Instantiate(Projectiles[2], Spawnpoints[2].transform.position, Quaternion.identity);
        //Instantiate(Projectiles[3], Spawnpoints[3].transform.position, Quaternion.identity);
        //Instantiate(Projectiles[4], Spawnpoints[4].transform.position, Quaternion.identity);
    }

    private GameObject RandomProjectile()
    {
        int randomProjectileIndex = Random.Range(0, Projectiles.Count);
        return Projectiles[randomProjectileIndex];
    }

    private Vector3 RandomSpawnPoint()
    {
        int randomSoawnPointIndex = Random.Range(0,Spawnpoints.Count);
        var randomOffset = Random.insideUnitCircle * 0.1F;

        var randomSpawnPoint = Spawnpoints[randomSoawnPointIndex].transform.position + (Vector3) randomOffset;
        return randomSpawnPoint;
    }

    IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < routine; i++)
        {
            Instantiate(RandomProjectile(), RandomSpawnPoint(), Quaternion.identity);

            yield return new WaitForSeconds(1.0f);
        }
    }


}
