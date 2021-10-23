using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightEmitter : MonoBehaviour
{
    private XRGrabInteractable interactable;
    [SerializeField] ColorPoint colorPoint;

    void Awake()
    {
        interactable = GetComponentInParent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(Grabbed);
        interactable.selectExited.AddListener(Released);
    }

    private void Released(SelectExitEventArgs arg0) {
        colorPoint.grounded = true;
    }

    private void Grabbed(SelectEnterEventArgs arg0) {
        colorPoint.grounded = false;
    }
}
