using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventExample : MonoBehaviour
{
    public UnityEvent OnCubeTouch;
    public UnityEvent OnCubeTouchEnd;

    private void OnTriggerEnter(Collider other)
    {
        OnCubeTouch.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        OnCubeTouchEnd.Invoke();
    }
}
