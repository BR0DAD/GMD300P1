using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCollectible : MonoBehaviour
{

    public float RotateSpeed = 50f;
    public Vector3 RotationAxis = Vector3.up;

  
    void Update()
    {
        transform.Rotate(RotationAxis * RotateSpeed * Time.deltaTime);
    }
}
