using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarnivoreControl : MonoBehaviour
{
    public Rigidbody2D playerRb;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        jump();
    }

   

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        playerRb.AddForce(Vector2.right * speed * horizontalInput);
        

        if (horizontalInput < 0)
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

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }
}
