using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("HAHAHAHAHAHA");
            GameObject.Find("3rd Person Character").GetComponent<ThirdCharacterController>().LoseHealth(1);
        }
        
    }
}
