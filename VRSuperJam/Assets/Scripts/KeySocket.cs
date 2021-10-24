using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeySocket : MonoBehaviour
{
    XRInteractionManager interactionManager;
    Door door;

    private void Start() {
        interactionManager = FindObjectOfType<XRInteractionManager>();
        door = GetComponentInParent<Door>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Key")) {
            var interactable = other.GetComponentInParent<XRGrabInteractable>();
            if (interactable.isSelected) {
                interactionManager.SelectExit(interactable.selectingInteractor, interactable);
                interactable.enabled = false;
                StartCoroutine(AttachKeyOpenDoor(other.gameObject));
            }
        }
    }

    private IEnumerator AttachKeyOpenDoor(GameObject key) {
        key.transform.SetParent(this.transform);
        key.transform.localPosition = Vector3.zero;
        door.OpenDoor();
        yield return new WaitForSeconds(1);
        Destroy(key.gameObject);
    }
}
