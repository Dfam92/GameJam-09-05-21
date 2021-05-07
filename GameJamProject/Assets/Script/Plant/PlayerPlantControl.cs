using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlantControl : MonoBehaviour
{
    public Rigidbody2D playerRb;
    private Animator playerAnim;

    [SerializeField] private float speed;
    [SerializeField] private float rootForce;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Boost();
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector2.right * speed * horizontalInput);
        playerRb.AddForce(Vector2.up * speed * verticalInput);
        if(horizontalInput != 0 || verticalInput != 0)
        {
            playerAnim.SetBool("IsMoving", true);
        }
        else
        {
            playerAnim.SetBool("IsMoving", false);
        }
        
        
    }

    private void Boost()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddRelativeForce(Vector2.down * rootForce, ForceMode2D.Impulse);
        }
    }
}
