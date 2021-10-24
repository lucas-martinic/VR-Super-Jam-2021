using UnityEngine;

public class DecoloredRenderer : MonoBehaviour {
    private Renderer _renderer;

    void Start() {
        _renderer = GetComponent<Renderer>();
        Color _color = _renderer.material.color;
        Texture texture = _renderer.material.mainTexture;
        _renderer.material = new Material(GameManager.Instance.decoloredMaterial);
        _renderer.material.color = _color;
        if(texture != null) {
            _renderer.material.mainTexture = texture;
        }
    }
}
