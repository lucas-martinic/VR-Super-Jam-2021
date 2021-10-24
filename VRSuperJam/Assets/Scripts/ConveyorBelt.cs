using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    private Rigidbody body = null;

    private void Update() {
        if(body != null) {
            body.transform.position += -transform.right / 2 * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<LightEmitter>() != null) {
            body = other.attachedRigidbody;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<LightEmitter>() != null) {
            body = null;
        }
    }
}
