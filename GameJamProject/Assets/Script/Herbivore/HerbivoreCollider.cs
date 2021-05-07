using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbivoreCollider : MonoBehaviour
{
    public GameObject bug;
    public GameObject carnivore;
    public Rigidbody2D herbivoreRb;

    public static bool herbivoreOn;
    Vector2 originalPos;

    // Start is called before the first frame update

    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Carnivore"))
        {
            transform.position = originalPos;
            CarnivoreCollider.carnivoreOn = true;
            this.gameObject.SetActive(false);
            herbivoreOn = false;
        }
    }

    
}

