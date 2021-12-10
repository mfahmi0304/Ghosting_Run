using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeasWait;
    public int startWait;
    public bool stop;

    int randEnemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeasWait, spawnMostWait);
    }

    IEnumerator waitSpawnEnemy()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            randEnemy = Random.Range(0, 2);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.z), 1, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate (enemies[randEnemy], spawnPosition + transform.TransformPoint (0,0,0), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }

}
