using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gravitySpeed;
    public static GameManager Instance;

    void Awake()
    {
        if(Instance == null) {
            Instance = this;
        }
    }
}
