using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreCollider : MonoBehaviour
{
    public GameObject bug;
    public Rigidbody2D carnivoreRb;

    public static bool carnivoreOn = true;

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

        if (collision.gameObject.CompareTag("Bug") && BugCollider.bugOn == false)
        {
            this.gameObject.GetComponent<PlayerControl>().enabled = false;
            carnivoreRb.drag = 5;
            bug.gameObject.GetComponent<PlayerControl>().enabled = true;
        }
    }
}
