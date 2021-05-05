using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlantControl : MonoBehaviour
{
    public Rigidbody2D playerRb;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {

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
    }
}
