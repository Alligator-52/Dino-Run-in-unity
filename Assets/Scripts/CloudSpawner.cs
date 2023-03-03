using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{ 
    [SerializeField] private float maxTime = 1f;
    
    [Header("Cloud")]
    [SerializeField] private GameObject[] clouds;
    [SerializeField] private float maxHeightCloud;
    [SerializeField] private float minHeightCloud;
    [SerializeField] private float destroyTimeCloud = 20f;

    private float timer = 0;
    

    private void Start()
    {
        SpawnCloud();
    }
    void Update()
    {
        if(timer > maxTime)
        {
            SpawnCloud();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void SpawnCloud()
    {
        int randomNum = Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomNum]);
        cloud.transform.position = new Vector3(transform.position.x, Random.Range(minHeightCloud, maxHeightCloud), transform.position.z);
        Destroy(cloud, destroyTimeCloud);
    }

   
}
