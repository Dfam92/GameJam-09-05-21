using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCollider : MonoBehaviour
{

    public GameObject item;
    
    public static bool isDigging;
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
        if(collision.gameObject.CompareTag("Herbivore") && isDigging == true)
        {
            SpawnItem();
            gameObject.SetActive(false);
        }
    }

    private void SpawnItem()
    {
        Instantiate(item,transform.position,transform.rotation);
    }

    
}
