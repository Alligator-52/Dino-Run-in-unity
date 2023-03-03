using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    [Header("Control Variables")]
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    
    private float destroyTime = 10f;
    private float thresholdTime = 120f;
    private float timer = 0f;

    private void Start()
    {
        StartCoroutine(Spawner());
    }
    private IEnumerator Spawner()
    {
        while (Time.timeScale == 1)
        {
            float height = Mathf.Round(Random.Range(minHeight, maxHeight));
            float time = Random.Range(minTime, maxTime);
            if (timer > thresholdTime)
            {
                yield return new WaitForSeconds(time);
                GameObject newPrefab = Instantiate(prefab, new Vector3(transform.position.x, height, transform.position.z), Quaternion.identity);
                Destroy(newPrefab, destroyTime);
            }
            timer += Time.deltaTime;
        }
        yield return null;
    }




}
