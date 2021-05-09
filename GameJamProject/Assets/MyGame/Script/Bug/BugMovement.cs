using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{
    [SerializeField] private float impulseForce;

    public GameObject bugObjective;
    public Rigidbody2D bugRb;

    private GameManager gameManager;

    public bool bugIsCollected;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    private void Awake()
    {
        Invoke("BugImpulse",0);
    }
    private void Update()
    {
        if (BugCollider.bugOn == true )
        {
            this.gameObject.GetComponent<PlayerBugControl>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.GetComponent<PlayerBugControl>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }

        if(gameManager.isActive==false)
        {
            bugRb.gravityScale = 0;
        }
        else
        {
            bugRb.gravityScale = 1.6f;
        }
    }
   
    private void BugImpulse()
    {
        if ( gameManager.isActive == true)
        {
            bugRb.AddForce(Vector3.up * impulseForce, ForceMode2D.Impulse);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BugObjective"))
        {
            gameManager.UpdateColection(1);
            Destroy(bugObjective);
            bugIsCollected = true;
        }
    }

}
