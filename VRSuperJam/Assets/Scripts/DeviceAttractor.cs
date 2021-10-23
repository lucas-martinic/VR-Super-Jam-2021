using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DeviceAttractor : MonoBehaviour
{
    private XRController controller = null;
    private XRDirectInteractor interactor = null;
    private LightEmitter device;
    [SerializeField] private float attractionSpeed = 20;
    [SerializeField] private float attractTimer = 3;
    [SerializeField] private float counter;
    [SerializeField] private bool interactorCanSelect = true;
    
    private void Awake() {
        controller = GetComponentInParent<XRController>();
        interactor = GetComponentInParent<XRDirectInteractor>();
        interactor.selectEntered.AddListener(interactorGrabbed);
        interactor.selectExited.AddListener(interactorReleased);
        device = FindObjectOfType<LightEmitter>();
    }

    private void interactorReleased(SelectExitEventArgs arg0) {
        interactorCanSelect = true;
    }

    private void interactorGrabbed(SelectEnterEventArgs arg0) {
        interactorCanSelect = false;
    }

    void Update()
    {
        CheckPointer();
    }
    private void CheckPointer() {
        if (interactorCanSelect) {
            if (controller.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
                AttractDevice(gripValue);
        }
    }

    private void AttractDevice(float value) {
        if(value > 0.5f) {
            counter += Time.deltaTime;
        } else {
            counter = 0;
        }
        if(counter >= attractTimer) {
            device.transform.position = Vector3.Lerp(device.transform.position, transform.position, Time.deltaTime * attractionSpeed);
            counter = attractTimer;
        }
        controller.SendHapticImpulse(Mathf.InverseLerp(0, attractTimer, counter/3), 0.01f);
    }
}
