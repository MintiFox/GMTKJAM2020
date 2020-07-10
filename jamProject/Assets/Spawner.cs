using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] patterns;
    public float time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
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
            yield return new WaitForSeconds(time);

            // SPAWN
            GameObject pattern = patterns[Random.Range(0, patterns.Length)];
            Instantiate(pattern, transform.position, Quaternion.identity);
        }   
    }
}
