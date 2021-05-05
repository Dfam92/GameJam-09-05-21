using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreMovement : MonoBehaviour
{
    
    public GameObject herbivore;
    public Rigidbody2D carnivoreRb;
    [SerializeField] private float speedCarnivore;



    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("CarnivoreMove", 1, 0.5f);
    }
    private void Update()
    {
        if (CarnivoreCollider.carnivoreOn == true)
        {
            CancelInvoke();
            this.gameObject.GetComponent<PlayerCarnivoreControl>().enabled = true;
        }
       else
        {
            this.gameObject.GetComponent<PlayerCarnivoreControl>().enabled = false;
        }
    }


    private void CarnivoreMove()
    {
        carnivoreRb.AddForce((herbivore.transform.position - transform.position) * speedCarnivore);
    }
}
