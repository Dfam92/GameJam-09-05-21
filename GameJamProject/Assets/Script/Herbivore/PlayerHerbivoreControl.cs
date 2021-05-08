using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHerbivoreControl : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public GameObject herbivoreObjective;
    [SerializeField] private float speed;
    private Animator playerAnim;

    
    public GameObject treasure;
    
   

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
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
            playerAnim.SetBool("IsMoving", true);
        }
        else if (horizontalInput > 0)
        {
            transform.GetChild(1).eulerAngles = new Vector3(0, 180, 0);
            playerAnim.SetBool("IsMoving", true);
        }
        else
        {
            playerAnim.SetBool("IsMoving", false);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (collision.gameObject.CompareTag("Treasure"))
            {
                Instantiate(herbivoreObjective, treasure.transform.position, treasure.transform.rotation);
                Destroy(treasure, 0.1f);
            }
        }
        

    }

}
