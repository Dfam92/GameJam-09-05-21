using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveObjective : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Herbivore"))
        {
            gameManager.UpdateColection(1);
            Destroy(gameObject);
        }
    }
}
