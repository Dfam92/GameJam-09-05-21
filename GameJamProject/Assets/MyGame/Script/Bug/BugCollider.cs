using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugCollider : MonoBehaviour
{
    public GameObject herbivore;
    public GameObject plant;
    public Rigidbody2D bugRb;

    public static bool bugOn = true;

    public bool wasEaten;
    public bool pantherDead;



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Plant"))
        {
            wasEaten = true;
            this.gameObject.SetActive(false);
            PlantCollider.plantOn = true;
            herbivore.gameObject.SetActive(true);   
        }
    }

    




}
