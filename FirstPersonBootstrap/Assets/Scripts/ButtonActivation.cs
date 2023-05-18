using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour
{
    public GameObject movingPlatform;
    public GameObject button;
    private Material buttonMat; 



    void Interact() {
        movingPlatform.GetComponent<Animator>().enabled = true;
        button.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        GetComponentInChildren<AudioSource>().Play();
    }
}
