using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BirdSpawn : MonoBehaviour
{
    [Header("Bird")]
    [SerializeField] private GameObject bird;
    [SerializeField] private float maxHeightBird;
    [SerializeField] private float minHeightBird;
    [SerializeField] private float destroyTimeBird = 8f;
    [SerializeField] private float thresholdTime = 120f;
    [SerializeField] private float maxTimeBird = 5f;
    private float birdTime = 0;
    private float timer = 0;

    private void Update()
    {
        if(birdTime > thresholdTime)
        {
            if(timer > maxTimeBird)
            {
                Invoke(nameof(SpawnBird), Random.Range(5, 15));
                timer = 0;
            }
            timer += Time.deltaTime;
        }
        birdTime += Time.deltaTime;
    }
    private void SpawnBird()
    {
        GameObject birdNew = Instantiate(bird);
        birdNew.transform.position = new Vector3(transform.position.x, Random.Range(minHeightBird, maxHeightBird), transform.position.z);
        Destroy(birdNew, destroyTimeBird);
    }
}
