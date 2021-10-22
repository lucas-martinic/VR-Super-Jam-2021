using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    private Rigidbody rigidBody;
    private bool affectedByGravity;
    [SerializeField] bool forceGravity;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (affectedByGravity || forceGravity) {
            rigidBody.AddForce(GameManager.Instance.Gravity * Time.deltaTime, ForceMode.Force);
        } else {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Gravity")) {
            if (GameManager.Instance.gravityInsideSphere) {
                affectedByGravity = true;
            } else {
                affectedByGravity = false;
                rigidBody.velocity = Vector3.zero;
                rigidBody.angularVelocity = Vector3.zero;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Gravity")) {
            if (GameManager.Instance.gravityInsideSphere) {
                affectedByGravity = false;
                rigidBody.velocity = Vector3.zero;
                rigidBody.angularVelocity = Vector3.zero;
            } else {
                affectedByGravity = true;
            }
        }
    }
}
