using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbivoreCollider : MonoBehaviour
{
    public GameObject carnivore;
    public Rigidbody2D herbivoreRb;

   

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

        if (collision.gameObject.CompareTag("Carnivore"))
        {
            this.gameObject.GetComponent<PlayerControl>().enabled = false;
            herbivoreRb.drag = 5;
            carnivore.gameObject.GetComponent<PlayerControl>().enabled = true;
        }
    }
}

