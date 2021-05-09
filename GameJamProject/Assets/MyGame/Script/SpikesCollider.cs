using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesCollider : MonoBehaviour
{
    public bool panterIsDead;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Carnivore"))
        {
            panterIsDead = true;      
        }
    }
}
