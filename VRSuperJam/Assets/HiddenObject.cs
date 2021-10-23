using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObject : MonoBehaviour
{
    private Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        Color _color = renderer.material.color;
        renderer.material = new Material(GameManager.Instance.invisibleMaterial);
        renderer.material.color = _color;
    }
}
