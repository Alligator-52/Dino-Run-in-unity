using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 2f;
    [SerializeField] private float destroyTime = 10f;
    [SerializeField] private float delay = 0.05f;
    [SerializeField] private GameObject[] obstacles;
    private float timer = 0;

    private void Update()
    {
        if(timer > maxTime)
        {
            int randomNum = Random.Range(0, obstacles.Length);
            GameObject newObstacle = Instantiate(obstacles[randomNum]);
            newObstacle.transform.position = new Vector3(transform.position.x,(float) -2.9, transform.position.z);
            Destroy(newObstacle, destroyTime);
            timer = 0;
        }
        timer += Time.deltaTime;
        maxTime -= delay * Time.deltaTime;
        if(maxTime < 0.8f)
        {
            maxTime = 0.8f;
        }

    }

}
