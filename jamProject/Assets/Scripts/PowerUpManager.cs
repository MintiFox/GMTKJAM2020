using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Dictionary<Type, uint> activated = new Dictionary<Type, uint>();
    public List<GameObject> sprites;

    [Header("Spawn Time")]
    public float minSpawnTime;
    public float maxSpawnTime;

    public static PowerUpManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else { Destroy(this); }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
    }

    void OnEnable()
    {
        StartCoroutine(SpawnCorountine());
    }

    private IEnumerator SpawnCorountine()
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnTime, maxSpawnTime));
            GameObject obj = Instantiate(
                sprites[UnityEngine.Random.Range(0, sprites.Count)], 
                transform.TransformPoint(new Vector2(UnityEngine.Random.Range(-0.5F, 0.5F), 0.0F)), 
                Quaternion.identity);
            obj.GetComponent<PowerUp>().manager = this;
        }
    }
}
