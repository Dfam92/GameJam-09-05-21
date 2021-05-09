using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlantControl : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public GameObject plantObjective;

    private Animator playerAnim;
    private GameManager gameManager;
    private HerbivoreMovement playerHerbivore;
    
    public bool isMoving;
    public bool isBoosting;
    public bool plantObjCollected;

    [SerializeField] private float speed;
    [SerializeField] private float rootForce;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAnim = GetComponentInChildren<Animator>();
        playerHerbivore = GameObject.Find("Herbivore").GetComponent<HerbivoreMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        PlantAnimation();
        Boost();

    }
    private void FixedUpdate()
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

    private void Boost()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddRelativeForce(Vector2.down * rootForce, ForceMode2D.Impulse);
            isBoosting = true;
        }
    }

    private void PlantAnimation()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        if (horizontalInput != 0 || verticalInput != 0)
        {
            playerAnim.SetBool("IsMoving", true);
            isMoving = true;

        }
        else
        {
            playerAnim.SetBool("IsMoving", false);
            isMoving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlantObjective"))
        {
            gameManager.UpdateColection(1);
            plantObjCollected = true;
            Destroy(plantObjective);
            playerHerbivore.speedHerbivore = 10;

        }
    }
}
