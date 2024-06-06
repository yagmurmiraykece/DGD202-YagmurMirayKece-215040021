using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed

    private Rigidbody2D rb;
    private bool facingRight = true;

    private Animator animator;

    private AudioSource audioSource;

    public int StarCount =0;

    public Text scoreText;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

        scoreText.text = StarCount.ToString();
    }

    void Update()
    {
        Move();
        Flip();

        if (rb.velocity.x > 0 || rb.velocity.x < 0)
        {
            animator.SetBool("isWalking", true);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    
        else
        {
            animator.SetBool("isWalking", false);
            audioSource.Stop();
        }

    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

    }

    void PlayerFootStep()
    {
        audioSource.Play();


    }

    void Flip()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput > 0 && !facingRight || moveInput < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            transform.localScale = scaler;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star")) 
        {
            StarCount++;
            scoreText.text = StarCount.ToString();
            Destroy(collision.gameObject);

        }
    }
}
