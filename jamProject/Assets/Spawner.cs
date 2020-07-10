using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Patterns;

    public float tbtwSpawn;
    public float startTbtwSpawn;
    public float dtime;
    public float minTime = 0.5f;
    public Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        tbtwSpawn = startTbtwSpawn;
    }

    void OnEnable()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnRoutine()
    {
        while (gameObject.activeInHierarchy)
        {
            // WAIT
            float timeToWait = Mathf.Max(tbtwSpawn -= dtime, minTime);
            yield return new WaitForSeconds(timeToWait);

            // SPAWN
            GameObject pattern = Patterns[Random.Range(0, Patterns.Length)];
            Instantiate(pattern, spawnPos, Quaternion.identity);
        }   
    }
}
