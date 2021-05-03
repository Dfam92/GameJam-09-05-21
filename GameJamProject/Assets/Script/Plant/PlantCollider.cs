using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCollider : MonoBehaviour
{
    public GameObject herbivore;
    public Rigidbody2D plantRb;

    public static bool plantOn = true;

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

        if (collision.gameObject.CompareTag("Herbivore"))
        {
            this.gameObject.GetComponent<PlayerControl>().enabled = false;
            plantRb.drag = 5;
            herbivore.gameObject.GetComponent<PlayerControl>().enabled = true;
        }

    }
}
