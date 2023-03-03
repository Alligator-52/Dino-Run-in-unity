using UnityEngine;

public class ObstalceMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    //private readonly float multiplier = 0.05f;
    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        //moveSpeed += multiplier * Time.deltaTime;
    }
}
