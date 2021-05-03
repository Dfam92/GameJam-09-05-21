using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugCollider : MonoBehaviour
{
    public GameObject plant;
    public Rigidbody2D bugRb;

   
    public static bool bugOn = true;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Plant"))
        {
            gameObject.GetComponent<PlayerControl>().enabled = false;
            bugRb.drag = 5;
            bugOn = false;
            plant.gameObject.GetComponent<PlayerControl>().enabled = true;
            plant.gameObject.GetComponent<PlantMovement>().enabled = false;
        }

    }

    
    
}
