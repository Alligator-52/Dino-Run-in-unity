using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpMaxTime = 2f;
    
    private Animator playerAnimator;
    private float jumpTime;
    private int clickCount;
    private bool isPressed = false;
    private bool isJumping = false;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isPressed = true;
            clickCount++;
        }
        if(Input.GetMouseButtonUp(0))
        {
            isPressed=false;
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            clickCount = 0;
            playerAnimator.SetBool("isJumping",false);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            playerAnimator.SetBool("isJumping", true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
    private void FixedUpdate()
    {
        JumpPlayer();
    }

    private void JumpPlayer()
    {
        
        if (isPressed && !isJumping)
        {
            jumpTime = jumpMaxTime;
            player.velocity = Vector3.up * jumpForce;
            isJumping = true;
        }

        if (isJumping && isPressed)
        {
            if (jumpTime > 0)
            {
                if(clickCount <1)
                {
                    player.velocity = Vector3.up * jumpForce;
                    jumpTime -= Time.deltaTime;
                }
            }
          
        }
        
    }
}
