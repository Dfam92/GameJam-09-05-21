using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarnivoreControl : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public GameObject carnivoreObjective;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Animator playerAnim;
    private bool isJumping;
    private bool isOnGround;
    public bool carnivoreIsMoving;

    private GameManager gameManager;

    private AudioSource audioPlayer;

    public AudioClip carnivoreWalk;
    public AudioClip carnivoreCollected;
    // Start is called before the first frame update
    void Start()
    {
        carnivoreObjective.SetActive(true);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAnim = GetComponentInChildren<Animator>();
        audioPlayer = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        jump();
        PlaySound();
    }
    
    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        playerRb.AddForce(Vector2.right * speed * horizontalInput);
        

        if (horizontalInput < 0)
        {
            transform.GetChild(1).eulerAngles = new Vector3(0, 0, 0);
            playerAnim.SetBool("IsMoving", true);
            carnivoreIsMoving = true;
        }
        else if (horizontalInput > 0)
        {
            transform.GetChild(1).eulerAngles = new Vector3(0, 180, 0);
            playerAnim.SetBool("IsMoving", true);
            carnivoreIsMoving = true;
        }
        else
        {
            playerAnim.SetBool("IsMoving", false);
            carnivoreIsMoving = false;
        }
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && isJumping == false) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            isOnGround = false;
            carnivoreIsMoving = false;
            
        }
        
    }

    private void PlaySound()
    {
        if(carnivoreIsMoving == true && isOnGround == true)
        {
            if(!audioPlayer.isPlaying)
            {
                audioPlayer.PlayOneShot(carnivoreWalk);
            }
        }
    }
   

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CarnivoreObjective"))
        {
            gameManager.UpdateColection(1);
            audioPlayer.PlayOneShot(carnivoreCollected);
            Destroy(carnivoreObjective);
        }
    }
}
