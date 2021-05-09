using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnePodre : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
       StartCoroutine(SelfDestruction());
    
    }

    IEnumerator SelfDestruction()
    {
        yield return new WaitForSeconds(15);
        Destroy(this.gameObject);
        
    }
}
