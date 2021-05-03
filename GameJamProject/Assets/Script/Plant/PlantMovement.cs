using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMovement : MonoBehaviour
{
    
    public Rigidbody2D plantRb;
    [SerializeField] private float speed;
    [SerializeField] private float timeToStartUp;
    [SerializeField] private float timeToStartDown;

    [SerializeField] private float timeToUp;
    [SerializeField] private float timeToDown;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpperMovement", timeToStartUp, timeToUp);
        InvokeRepeating("DownMovement", timeToStartDown, timeToDown);
    }

    // Update is called once per frame
    void Update()
    {
       if(PlantCollider.plantOn == true)
        {
            CancelInvoke();
            this.gameObject.GetComponent<PlayerControl>().enabled = true;

        }
        else
        {
            this.gameObject.GetComponent<PlayerControl>().enabled = false;
        }
    }

   

    private void UpperMovement()
    {
        
        plantRb.AddRelativeForce(Vector2.up *speed);
       
    }
    private void  DownMovement()
    {
        
       plantRb.AddRelativeForce(Vector2.down*speed);
           
    }
}
