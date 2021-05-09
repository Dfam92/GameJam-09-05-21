using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioPlayer;
    private BugCollider playerBug;
    private PlayerPlantControl playerPlant;
    private PlantCollider plantCollider;
    private SpikesCollider spikes;
    private BugMovement bugMove;
   
    public AudioClip bite;
    public AudioClip rootMoving;
    public AudioClip rootBoost;
    public AudioClip plantEaten;
    public AudioClip pantherRoar;
    public AudioClip objectiveSound;
  
    private bool isStop = true;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        playerBug = GameObject.Find("bug").GetComponent<BugCollider>();
        playerPlant = GameObject.Find("Raiz").GetComponent<PlayerPlantControl>();
        plantCollider = GameObject.Find("Plant").GetComponent<PlantCollider>();
        spikes = GameObject.Find("Spikes").GetComponent<SpikesCollider>();
        bugMove = GameObject.Find("bug").GetComponent<BugMovement>();
    }
   
    // Update is called once per frame
    void Update()
    {
        PlaySounds();
      
    }

    private void PlaySounds()
    {
        if (playerBug.wasEaten == true)
        {
            if (!audioPlayer.isPlaying)
                audioPlayer.PlayOneShot(bite, 0.5f);
            playerBug.wasEaten = false;

        }
        else if (playerPlant.plantObjCollected == true)
        {
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.PlayOneShot(objectiveSound, 0.5f);
                playerPlant.plantObjCollected = false;
            }
        }
        else if (DesactiveObjective.isCollected == true && isStop == true)
        {
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.PlayOneShot(objectiveSound, 0.5f);
                isStop = false;
            }
        }
        else if (bugMove.bugIsCollected == true)
        {
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.PlayOneShot(objectiveSound, 0.5f);
                bugMove.bugIsCollected = false;
            }
        }
        else if (playerPlant.isBoosting == true)
        {
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.PlayOneShot(rootBoost);
                playerPlant.isBoosting = false;
            }

        }
        else if (playerPlant.isMoving == true)
        {
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.PlayOneShot(rootMoving);
                playerPlant.isMoving = false;
            }

        }
        else if (plantCollider.plantWasEaten == true)
        {

            if (!audioPlayer.isPlaying)
            {
                audioPlayer.PlayOneShot(plantEaten);
                plantCollider.plantWasEaten = false;
            }
        }
        else if (spikes.panterIsDead == true)
        {
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.PlayOneShot(pantherRoar, 0.5f);
                spikes.panterIsDead = false;
            }
        }
    }

    

   
}
