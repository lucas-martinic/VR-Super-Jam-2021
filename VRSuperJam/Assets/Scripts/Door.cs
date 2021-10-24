using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] HandButton openButton;
    bool opened;

    // Start is called before the first frame update
    void Start()
    {
        openButton.OnPress.AddListener(OpenDoor);
    }

    private void OnDestroy() {
        openButton.OnPress.RemoveListener(OpenDoor);
    }

    private void OpenDoor() {
        if(!opened)
            StartCoroutine(Co_OpenDoor());
    }

    IEnumerator Co_OpenDoor() {
        opened = true;
        for (float i = 0; i < 2; i += Time.deltaTime) {
            transform.position += transform.right * Time.deltaTime;
            yield return null;
        }
    }
}
