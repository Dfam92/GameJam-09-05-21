using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHerbivoreControl : MonoBehaviour
{
    public Rigidbody2D playerRb;

    [SerializeField] private float speed;
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
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector2.right * speed * horizontalInput);
        playerRb.AddForce(Vector2.up * speed * verticalInput);
        
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
}
