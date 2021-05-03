using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{
    
    public GameObject carnivore;
    public Rigidbody2D bugRb;
    [SerializeField] private float speedbug;



    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Awake()
    {
        InvokeRepeating("BugMove", 1, 0.5f);
    }
    private void Update()
    {
        if (BugCollider.bugOn == true)
        {
            CancelInvoke();
            this.gameObject.GetComponent<PlayerControl>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<PlayerControl>().enabled = false;
        }
    }


    private void BugMove()
    {
        
        
        bugRb.AddForce((carnivore.transform.position - transform.position) * speedbug);
        
        
    }
}
