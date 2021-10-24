using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : MonoBehaviour
{
    [SerializeField] XRBaseInteractable openMechanism;
    private AudioSource audioSource;
    bool opened;

    // Start is called before the first frame update
    void Start()
    {
        if(openMechanism != null) {
            openMechanism.selectEntered.AddListener(OpenDoor);
        }
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy() {
        if (openMechanism != null) {
            openMechanism.selectEntered.RemoveListener(OpenDoor);
        }
    }

    [ContextMenu("OpenDoor")]
    private void OpenDoor(SelectEnterEventArgs arg0) {
        if(!opened)
            StartCoroutine(Co_OpenDoor());
    }

    IEnumerator Co_OpenDoor() {
        opened = true;
        if(audioSource != null) {
            audioSource.Play();
        }
        for (float i = 0; i < 1.5f; i += Time.deltaTime) {
            transform.position += transform.right * Time.deltaTime;
            yield return null;
        }
    }
}
