using UnityEngine;

public class GroundMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float resetPos;
    [SerializeField] private float nextPos;
    //private readonly float multiplier = 0.05f;

    private void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        if (transform.position.x < resetPos)
        {
            transform.position = new Vector3(nextPos, transform.position.y, transform.position.z);
        }
        //moveSpeed += multiplier * Time.deltaTime;
    }
}
