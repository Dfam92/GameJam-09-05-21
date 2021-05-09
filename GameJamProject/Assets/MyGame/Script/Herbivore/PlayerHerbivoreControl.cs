using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHerbivoreControl : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public GameObject herbivoreObjective;
    public float speed = 5;
    private Animator playerAnim;
    private AudioSource audioPlayer;
    

    public AudioClip herbivoreWalk;
    public AudioClip digging;

    public List<GameObject> earths;
    public GameObject treasure;
    public bool herbivoreIsMoving = false;
   

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlaySound();
       
        
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector2.right * speed * horizontalInput);
        
        if(horizontalInput < 0)
        {
            transform.GetChild(1).eulerAngles = new Vector3(0, 0, 0);
            playerAnim.SetBool("IsMoving", true);
            herbivoreIsMoving = true;
            
        }
        else if (horizontalInput > 0)
        {
            transform.GetChild(1).eulerAngles = new Vector3(0, 180, 0);
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
