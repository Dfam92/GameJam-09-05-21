using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreCollider : MonoBehaviour
{
    public GameObject plant;
    public GameObject bug;
    public Rigidbody2D carnivoreRb;

    public static bool carnivoreOn;

    private Vector2 deathPos;
    private Vector2 originalPos;
    [SerializeField] private Vector2 offSetPos;

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
       if (collision.gameObject.CompareTag("Spikes"))
        {
            deathPos = transform.position;
            bug.transform.position = deathPos + offSetPos;
            transform.position = originalPos;
            BugCollider.bugOn = true;
            this.gameObject.SetActive(false);
            plant.gameObject.SetActive(true);
            carnivoreOn = false;
            bug.SetActive(true);
        }
    }

    
}
