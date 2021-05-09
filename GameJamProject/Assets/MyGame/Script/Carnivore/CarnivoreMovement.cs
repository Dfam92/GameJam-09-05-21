using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreMovement : MonoBehaviour
{
    
    public GameObject herbivore;
    public Rigidbody2D carnivoreRb;
    
    private Animator playerAnim;
  
    private CarnivoreCollider carnivoreCollider;
    private GameManager gameManager;

    [SerializeField] private float speedCarnivore;

    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        carnivoreCollider = GameObject.Find("Carnivore").GetComponent<CarnivoreCollider>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }

    private void Update()
    {

        if (carnivoreCollider.carnivoreOn == true)
        {
            this.gameObject.GetComponent<PlayerCarnivoreControl>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            CancelInvoke();
            isMoving = false;
        }
       else
        {
            this.gameObject.GetComponent<PlayerCarnivoreControl>().enabled = false;
            isMoving = true;
        }

        if(isMoving == true)
        {
            StartCoroutine(Moving());
            isMoving = false;
        }
    }

    private void CarnivoreMove()
    {
        if(carnivoreCollider.carnivoreOn == false)
        {
            carnivoreRb.AddForce(Vector2.right * speedCarnivore, ForceMode2D.Impulse);
            playerAnim.SetBool("IsMoving", true);
            transform.GetChild(1).eulerAngles = new Vector3(0, 180, 0);
        }
    }

   IEnumerator Moving()
    {
        while (gameManager.isActive == true)
        {
            yield return new WaitForSeconds(10);
            InvokeRepeating("CarnivoreMove", 5, 5);
        }
    }
}
