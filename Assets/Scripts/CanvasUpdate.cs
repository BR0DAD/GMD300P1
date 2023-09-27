using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasUpdate : MonoBehaviour
{

    public TMP_Text CollectibleText;
    public MyManager MyManager;

    // Update is called once per frame
    void Update()
    {
        CollectibleText.text = MyManager.playerScore.ToString();
    }
}
