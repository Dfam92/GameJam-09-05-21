using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCollider : MonoBehaviour
{
    public GameObject carnivore;
    public GameObject herbivore;
    public Rigidbody2D plantRb;

    public static bool plantOn;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Herbivore"))
        {
            
            
            transform.position = originalPos;
            HerbivoreCollider.herbivoreOn = true;
            this.gameObject.SetActive(false);
            carnivore.gameObject.SetActive(true);
            plantOn = false;
            
        }

    }
}
