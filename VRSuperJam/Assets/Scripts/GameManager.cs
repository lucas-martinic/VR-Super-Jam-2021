using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gravitySpeed = 100;
    public Vector3 Gravity {
        get {
            if (gravityInverted) {
                return new Vector3(0, gravitySpeed, 0);
            } else {
                return new Vector3(0, -gravitySpeed, 0);
            }
        }
    }
    public static GameManager Instance;
    public bool gravityInverted = false;
    public bool gravityInsideSphere = true;
    public bool randomPushUpwardsWhenGravityOff = true;
    
    void Awake()
    {
        if(Instance == null) {
            Instance = this;
        }
    }
}
