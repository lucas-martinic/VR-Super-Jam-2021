using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    private Rigidbody rigidBody;
    private bool affectedByGravity;
    private Vector3 gravityForce = new Vector3(0, GameManager.Instance.gravitySpeed, 0);

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (affectedByGravity) {
            rigidBody.AddForce(gravityForce * Time.deltaTime, ForceMode.Force);
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
