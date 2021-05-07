using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbivoreMovement : MonoBehaviour
{
    public GameObject plant;
    public Rigidbody2D herbivoreRb;
    private Animator playerAnim;
    public GameObject herbivoreObjective;

    [SerializeField] private float speedHerbivore;

    // Start is called before the first frame update
    private void Start()
    {
        herbivoreObjective.SetActive(true);
        playerAnim = GetComponentInChildren<Animator>();
    }
    void Awake()
    {
        InvokeRepeating("HerbivoreMove", 1, 0.5f);
        
    }
    private void Update()
    {
        if(HerbivoreCollider.herbivoreOn == true)
        {
            
            this.gameObject.GetComponent<PlayerHerbivoreControl>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            Dig();
            


        }
        else
        {
            this.gameObject.GetComponent<PlayerHerbivoreControl>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            

        }
        
    }

    

    private void HerbivoreMove()
    {
        if(HerbivoreCollider.herbivoreOn == false)
        {
            herbivoreRb.AddForce((plant.transform.position - transform.position) * speedHerbivore);
            playerAnim.SetBool("IsMoving", true);
            transform.GetChild(1).eulerAngles = new Vector3(0, 180, 0);


        }
        
    }

    private void Dig()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            EarthCollider.isDigging = true;
            StartCoroutine(stopDig());
        }
       
    }

    IEnumerator stopDig()
    {
        yield return new WaitForSeconds(0.5f);
        EarthCollider.isDigging = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HerbivoreObjective"))
        {
            Destroy(herbivoreObjective);
        }
    }
}
