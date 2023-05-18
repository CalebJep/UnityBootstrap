using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    private bool triggered = false;

    private void Update() {
        if (Input.GetKeyDown(interactKey) && !triggered) {
            triggered = true;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 2))
            {
                hit.collider.SendMessage("Interact");
            }
        }
        else if (Input.GetKeyUp(interactKey)) {
            triggered = false;
        }
    }
}
