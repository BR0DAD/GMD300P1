using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MyManager.Instance.AddScore(1);

            Destroy(this.gameObject);
        }
    }
}
