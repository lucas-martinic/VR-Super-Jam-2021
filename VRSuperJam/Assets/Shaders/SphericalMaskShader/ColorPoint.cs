using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPoint : MonoBehaviour
{
    public GameObject sphere;
    [SerializeField] private float maxSize = 4;
    [SerializeField] private float shrinkingSpeed = 8f;
    [SerializeField] private float growingSpeed = 4f;
    public bool grounded = true;

    private float currentSize = 0;
    Vector3 _mousePos, _smoothPoint;
    public float _softness = 0.5f, _smoothSpeed = 40, _scaleFactor = 2;

    void Update()
    {
        if (grounded) {
            Grow();
        } else {
            Shrink();
        }
    }

    private void Shrink() {
        if(sphere.transform.localScale.x > 0) {
            currentSize -= shrinkingSpeed * Time.deltaTime;
        } else {
            currentSize = 0;
        }
        SetValues();
    }
    private void Grow() {
        if (sphere.transform.localScale.x < maxSize) {
            currentSize += growingSpeed * Time.deltaTime;
        } else {
            currentSize = maxSize;
        }
        SetValues();
    }

    private void SetValues() {
        Mathf.Clamp(currentSize, 0, 100);
        Mathf.Clamp(_softness, 0, 100);

        sphere.transform.localScale = (new Vector3(currentSize, currentSize, currentSize));

        Shader.SetGlobalVector("GLOBALmask_Position", new Vector4(transform.position.x, transform.position.y, transform.position.z, 0));
        Shader.SetGlobalFloat("GLOBALmask_Radius", currentSize / 2);
        Shader.SetGlobalFloat("GLOBALmask_Softness", _softness);

        Shader.SetGlobalVector("_GLOBALMaskPosition", transform.position);
        Shader.SetGlobalFloat("_GLOBALMaskRadius", currentSize / 2);
        Shader.SetGlobalFloat("_GLOBALMaskSoftness", 0);
    }
}
