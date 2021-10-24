using UnityEngine;

public class DecoloredRenderer : MonoBehaviour {
    private Renderer _renderer;

    void Start() {
        _renderer = GetComponent<Renderer>();
        Color _color = _renderer.material.color;
        _renderer.material = new Material(GameManager.Instance.decoloredMaterial);
        _renderer.material.color = _color;
    }
}
