using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BraceletPowers : MonoBehaviour
{
    [SerializeField] GameObject lantern;
    [SerializeField] GameObject bracelet;
    XRController leftController;
    bool hasBracelet = false;
    bool transformControlActive = false;
    bool playerHoldingLantern = false;
    Vector3 initialLanternPosition;
    Vector3 lanternPosition;
    Vector3 initialBraceletPosition;
    Vector3 braceletPosition;
    float varianceX;
    float varianceY;
    float varianceZ;


    // Start is called before the first frame update
    void Start()
    {
        leftController = GetComponent<XRController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBracelet)
        {
            GetVariance();
            TransformControl();
        }
    }

    public void SetHasBracelet()
    {
        hasBracelet = !hasBracelet;
        leftController.SendHapticImpulse(1, 0.2f);
        // print("Bracelet attached/detached");
    }

/*    void SetPlayerHoldingLanternActive()
    {
        playerHoldingLantern = !playerHoldingLantern;
    }*/

    public void GetInitialPositions()
    {
        if (hasBracelet)  //  && leftController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)
        {
            GetTransformOfLantern();
            GetTransformOfBracelet();
            print(initialBraceletPosition);
        }
    }

    void GetTransformOfLantern()
    {
        initialLanternPosition = lantern.transform.position;
    }

    void GetTransformOfBracelet()
    {
        initialBraceletPosition = bracelet.transform.position;
    }

    void GetVariance()
    {
        varianceX = braceletPosition.x - initialBraceletPosition.x;
        varianceY = braceletPosition.y - initialBraceletPosition.y;
        varianceZ = braceletPosition.z - initialBraceletPosition.z;
    }

    void TransformControl()
    {
        if (hasBracelet && leftController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool triggerButton))
        {
            initialLanternPosition += new Vector3(varianceX, varianceY, varianceZ);
        }
    }
}
