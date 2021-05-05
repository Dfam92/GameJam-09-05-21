using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugCollider : MonoBehaviour
{
    public GameObject herbivore;
    public GameObject plant;
    public Rigidbody2D bugRb;

    Vector2 originalPos;
    public static bool bugOn = true;


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

        if (collision.gameObject.CompareTag("Plant"))
        {
            
            this.gameObject.SetActive(false);
            transform.position = originalPos;
            PlantCollider.plantOn = true;
            herbivore.gameObject.SetActive(true);
            bugOn = false;
           
        }

    }

   

    
    
}
