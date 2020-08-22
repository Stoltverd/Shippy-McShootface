using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues = new Vector3();
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    Pooler pooler;

    void Start()
    {
        pooler = Pooler.Instance;

       StartCoroutine (SpawnWaves());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait); //Esperamos antes de tirarle cosas al principio
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                //Spawn from pool
                pooler.SpawnFromPool("Asteroid", spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);//esperamos antes de hacer otro ciclo
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
