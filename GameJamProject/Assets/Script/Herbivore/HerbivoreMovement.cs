using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbivoreMovement : MonoBehaviour
{
    public GameObject plant;
    public Rigidbody2D herbivoreRb;
    [SerializeField] private float speedHerbivore;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("HerbivoreMove", 1, 0.5f);
    }
    private void Update()
    {
        if(HerbivoreCollider.herbivoreOn == true)
        {
            CancelInvoke();
            this.gameObject.GetComponent<PlayerHerbivoreControl>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<PlayerHerbivoreControl>().enabled = false;
        }
    }

    private void HerbivoreMove()
    {
        herbivoreRb.AddForce(( plant.transform.position - transform.position)*speedHerbivore);
    }
}
