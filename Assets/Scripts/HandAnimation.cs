using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class HandAnimation : MonoBehaviour
{
    public InputActionProperty pinchAim;
    public InputActionProperty gripAnim;

    public Animator handAnimator;
    void Update()
    {
        HandAnimationControl();
    }
    void HandAnimationControl()
    {
        //Control both trigger and grip animations
        float pinchTrigger = pinchAim.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", pinchTrigger);

        float gripAction = gripAnim.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripAction);
    }
}
