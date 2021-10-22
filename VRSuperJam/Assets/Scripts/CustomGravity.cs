using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    private Rigidbody rigidBody;
    private bool affectedByGravity;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (affectedByGravity) {
            rigidBody.AddForce(GameManager.Instance.Gravity * Time.deltaTime, ForceMode.Force);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Gravity")) {
            affectedByGravity = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Gravity")) {
            affectedByGravity = false;
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }
    }
}
