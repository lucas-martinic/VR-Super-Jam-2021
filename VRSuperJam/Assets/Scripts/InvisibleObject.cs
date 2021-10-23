using UnityEngine;

public class InvisibleObject : MonoBehaviour
{
    private Renderer _renderer;
    private Collider _collider;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _collider = GetComponent<Collider>();
        Color _color = _renderer.material.color;
        _renderer.material = new Material(GameManager.Instance.invisibleMaterial);
        _renderer.material.color = _color;
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Gravity")) {
            if(_collider != null) {
                _collider.isTrigger = false;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Gravity")) {
            if(_collider != null) {
                 _collider.isTrigger = true;
            }
        }
    }
}
