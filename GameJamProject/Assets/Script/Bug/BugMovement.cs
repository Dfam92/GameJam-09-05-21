using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{

    public GameObject bugObjective;
    public Rigidbody2D bugRb;
    [SerializeField] private float impulseForce;
 
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Awake()
    {
        Invoke("BugImpulse",0);
    }
    private void Update()
    {
        if (BugCollider.bugOn == true)
        {
            
            this.gameObject.GetComponent<PlayerBugControl>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
         
        }
        else
        {
            
            this.gameObject.GetComponent<PlayerBugControl>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            
        }
    }
   
    private void BugImpulse()
    {
        if (BugCollider.bugOn == true)
        {
            bugRb.AddForce(Vector3.up * impulseForce, ForceMode2D.Impulse);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BugObjective"))
        {
            Destroy(bugObjective);
        }
    }

}
