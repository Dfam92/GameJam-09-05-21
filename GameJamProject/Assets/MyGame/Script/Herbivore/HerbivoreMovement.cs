using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbivoreMovement : MonoBehaviour
{
    public GameObject plant;
    public Rigidbody2D herbivoreRb;

    private Animator playerAnim;
    private HerbivoreCollider herbivoreCollider;

    public float speedHerbivore;
    

    // Start is called before the first frame update
    private void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        herbivoreCollider = GameObject.Find("Herbivore").GetComponent<HerbivoreCollider>();
    }
    void Awake()
    {
        InvokeRepeating("HerbivoreMove", 1, 0.5f);
    }
    private void Update()
    {
        if(herbivoreCollider.herbivoreOn == true)
        {
            this.gameObject.GetComponent<PlayerHerbivoreControl>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<PlayerHerbivoreControl>().enabled = false;
        }
       
    }

    private void HerbivoreMove()
    {
        if(herbivoreCollider.herbivoreOn == false)
        {
            herbivoreRb.AddForce((plant.transform.position - transform.position) * speedHerbivore);
            playerAnim.SetBool("IsMoving", true);
            transform.GetChild(1).eulerAngles = new Vector3(0, 180, 0);
        }
        
    }

    

    
}
