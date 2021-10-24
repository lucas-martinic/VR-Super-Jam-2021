using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] HandButton openButton;
    private AudioSource audioSource;
    bool opened;

    // Start is called before the first frame update
    void Start()
    {
        openButton.OnPress.AddListener(OpenDoor);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy() {
        openButton.OnPress.RemoveListener(OpenDoor);
    }

    [ContextMenu("OpenDoor")]
    private void OpenDoor() {
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
