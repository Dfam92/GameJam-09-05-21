using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHerbivoreControl : MonoBehaviour
{
    private Animator playerAnim;
    private AudioSource audioPlayer;

    public Rigidbody2D playerRb;
    public AudioClip herbivoreWalk;
    public AudioClip digging;

    public List<GameObject> earths;
    public GameObject treasure;
    public GameObject herbivoreObjective;

    public bool herbivoreIsMoving = false;
    public float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlaySound();
        HerbivoreAnimation();
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector2.right * speed * horizontalInput);
        
        if(horizontalInput < 0)
        {
            transform.GetChild(1).eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontalInput > 0)
        {
            transform.GetChild(1).eulerAngles = new Vector3(0, 180, 0);
        }
        
    }

    private void HerbivoreAnimation()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        

        if (horizontalInput < 0)
        {
            playerAnim.SetBool("IsMoving", true);
            herbivoreIsMoving = true;

        }
        else if (horizontalInput > 0)
        {
            playerAnim.SetBool("IsMoving", true);
            herbivoreIsMoving = true;
        }
        else
        {
            playerAnim.SetBool("IsMoving", false);
            herbivoreIsMoving = false;
        }
    }

    private void PlaySound()
    {
        if(herbivoreIsMoving == true)
        {
            if(!audioPlayer.isPlaying)
            {
                audioPlayer.PlayOneShot(herbivoreWalk, 1);
                herbivoreIsMoving = false;
            }
        }
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(GameObject earth in earths)
            {
                if(collision.CompareTag("Earth"))
                {
                    audioPlayer.PlayOneShot(digging, 0.1f);
                }
            }
            
            if (collision.gameObject.CompareTag("Treasure"))
            {
                Instantiate(herbivoreObjective, treasure.transform.position, treasure.transform.rotation);
                audioPlayer.PlayOneShot(digging, 0.1f);
                Destroy(treasure, 0.1f);
            }
            
        }
        

    }

}
