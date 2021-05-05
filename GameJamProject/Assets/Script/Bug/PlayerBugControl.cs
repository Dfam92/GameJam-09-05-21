using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBugControl : MonoBehaviour
{
    public Rigidbody2D playerRb;

    [SerializeField] private float speed;
    [SerializeField] private float speedFly;
    private Animator bugAnim;
    // Start is called before the first frame update
    void Start()
    {
        bugAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    
    void Update()
    {
        PlayerBugAnim();
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector2.right * speed * horizontalInput);
       
    }
    private void PlayerBugAnim()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector2.up * speedFly, ForceMode2D.Impulse);
            bugAnim.SetInteger("Fly", 1);
        }
        else
        {
            bugAnim.SetInteger("Fly", 0);

        }
    }
}
