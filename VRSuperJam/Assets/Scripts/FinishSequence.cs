using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSequence : MonoBehaviour
{
    [SerializeField] Rigidbody xrRigRigidBody;
    [SerializeField] Transform camera;

    public void FinalSequence() {
        xrRigRigidBody.constraints = RigidbodyConstraints.None;
        xrRigRigidBody.AddForceAtPosition(-xrRigRigidBody.transform.right, camera.position);
    }
}
