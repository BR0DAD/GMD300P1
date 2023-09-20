using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorDestruction : MonoBehaviour
{
    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
