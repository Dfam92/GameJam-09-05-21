using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreCollider : MonoBehaviour
{
    public GameObject plant;
    public GameObject bug;
    public Rigidbody2D carnivoreRb;
    public GameObject carnePodre;
    public AudioClip biteHerbivore;

    private AudioSource audioPlayer;

    public bool carnivoreOn;

    private bool wasEaten;

    private Vector2 deathPos;
    private Vector2 originalPos;

    [SerializeField] private Vector2 offSetPos;

    // Start is called before the first frame update

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        originalPos = gameObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        PlaySound();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Herbivore"))
        {
            wasEaten = true;
        }
    }
    private void PlaySound()
    {
        if(wasEaten == true)
        {
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.PlayOneShot(biteHerbivore, 1);
                wasEaten = false;
            }
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Spikes"))
        {
            Instantiate(carnePodre, transform.position,carnePodre.transform.rotation);
            deathPos = transform.position;
            bug.transform.position = deathPos + offSetPos;
            transform.position = originalPos;
            BugCollider.bugOn = true;
            this.gameObject.SetActive(false);
            plant.gameObject.SetActive(true);
            carnivoreOn = false;
            bug.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
            
        }
    }

    
    
   
}
