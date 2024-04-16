using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GazeInteraction : MonoBehaviour
{
    public Text Points;
    public Text Timer;

    void Update()
    {
        GazeInteractionUI();  
    }

    void GazeInteractionUI()
    {
        //Raycast from the camera
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //Check if the object is colliding with the Texts
            if (hit.collider.gameObject == gameObject)
            {
                // If the raycast is colliding enable texts
                Points.enabled = true;
                Timer.enabled = true;
            }
            else
            {
                // If the player moves away disable the texts
                Points.enabled = false;
                Timer.enabled = false;
            }
        }
    }
}
