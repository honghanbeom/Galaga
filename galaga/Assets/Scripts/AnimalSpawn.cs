using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawn : MonoBehaviour
{
    public GameObject []animalPrefab;
    public float spawnRate;
    public float spawnRateMax = 0.5f;
    public float spawnRateMin = 3f;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            int animalRandom = Random.Range(0,5);
            GameObject animal = Instantiate(animalPrefab[animalRandom],
                transform.position,
                transform.rotation);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        }
    }
}
