using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Haptics : MonoBehaviour
{
    [Range(0, 1)]
    public float hapticIntense;
    public float timer;

    void Start()
    {
        //Get hand interactable
     XRBaseInteractable interact = GetComponent<XRBaseInteractable>();
        interact.activated.AddListener(HapticShooting);
    }
   
    public void HapticShooting(BaseInteractionEventArgs args)
    {
        //Send haptic vibration if its the xr controller
        if (args.interactorObject is XRBaseControllerInteractor controllerInteractor)  {
            HapticController(controllerInteractor.xrController);
                };
    }

    public void HapticController(XRBaseController controller)
    {
        //Adjust the intensity of the haptic
        if(hapticIntense > 0)  { controller.SendHapticImpulse(hapticIntense, timer);
        }
    }
}
