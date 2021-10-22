using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPoint : MonoBehaviour
{
    public GameObject sphere;
    Vector3 _mousePos, _smoothPoint;
    public float _radius = 4, _softness = 0.5f, _smoothSpeed = 40, _scaleFactor = 2;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _radius += _scaleFactor * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _radius -= _scaleFactor * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _softness += _scaleFactor * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _softness -= _scaleFactor * Time.deltaTime;
        }
        Mathf.Clamp(_radius, 0, 100);
        Mathf.Clamp(_softness, 0, 100);

        sphere.transform.localScale = (new Vector3(_radius, _radius, _radius));

        Shader.SetGlobalVector("GLOBALmask_Position", new Vector4(transform.position.x, transform.position.y, transform.position.z, 0));
        Shader.SetGlobalFloat("GLOBALmask_Radius", _radius/2);
        Shader.SetGlobalFloat("GLOBALmask_Softness", _softness);

        Shader.SetGlobalVector("_GLOBALMaskPosition", transform.position);
        Shader.SetGlobalFloat("_GLOBALMaskRadius", _radius / 2);
        Shader.SetGlobalFloat("_GLOBALMaskSoftness", _softness);
    }
}
