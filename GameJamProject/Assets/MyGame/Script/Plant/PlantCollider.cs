using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCollider : MonoBehaviour
{
    public GameObject carnivore;
    public GameObject herbivore;
    public Rigidbody2D plantRb;
    private HerbivoreCollider herbivoreCollider;
    public bool plantWasEaten;
    public static bool plantOn;
    Vector2 originalPos;

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

        if (collision.gameObject.CompareTag("Herbivore"))
        {
            herbivoreCollider = GameObject.Find("Herbivore").GetComponent<HerbivoreCollider>();
            transform.position = originalPos;
            herbivoreCollider.herbivoreOn = true;
            carnivore.gameObject.SetActive(true);
            plantOn = false;
            herbivore.transform.GetChild(0).gameObject.SetActive(true);
            plantWasEaten = true;
            StartCoroutine(DestroyPlants());
        }

    }

    IEnumerator DestroyPlants()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
    
}
