using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    public int CollectibleRequired = 1;

    private int lastUpdatedSlot = 0;

    private void Update()
    {
        if (MyManager.Instance.GetScoreTotal() > lastUpdatedSlot)
        {
            lastUpdatedSlot++;
            

            if (lastUpdatedSlot == CollectibleRequired)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
