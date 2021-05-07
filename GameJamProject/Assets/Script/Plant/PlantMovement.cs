using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMovement : MonoBehaviour
{
    
    public Rigidbody2D plantRb;
    public GameObject plantObjective;


   
    // Update is called once per frame
    void Update()
    {
       if(PlantCollider.plantOn == true)
        {
          
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.GetComponent<PlayerPlantControl>().enabled = true;
            transform.GetChild(1).gameObject.SetActive(true);
         
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.GetComponent<PlayerPlantControl>().enabled = true;
            transform.GetChild(1).gameObject.SetActive(false);
            

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlantObjective"))
        {
            Destroy(plantObjective);
        }
    }

}
