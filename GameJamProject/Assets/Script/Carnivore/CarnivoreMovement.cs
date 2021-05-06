using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreMovement : MonoBehaviour
{
    
    public GameObject herbivore;
    public Rigidbody2D carnivoreRb;
    private Animator playerAnim;

    [SerializeField] private float speedCarnivore;



    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
    } 
    private void Awake()
    {
        InvokeRepeating("CarnivoreMove", 1, 0.5f);
    }
    private void Update()
    {
        if (CarnivoreCollider.carnivoreOn == true)
        {
            
            this.gameObject.GetComponent<PlayerCarnivoreControl>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
       else
        {
            this.gameObject.GetComponent<PlayerCarnivoreControl>().enabled = false;
           
        }
    }

    

    private void CarnivoreMove()
    {
        if (CarnivoreCollider.carnivoreOn == false)
        {
            carnivoreRb.AddForce((herbivore.transform.position - transform.position) * speedCarnivore);
            playerAnim.SetBool("IsMoving", true);
            transform.GetChild(1).eulerAngles = new Vector3(0, 180, 0);
        }
            
    }
}
