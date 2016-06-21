using UnityEngine;

public class RandomRotator : MonoBehaviour
{

    public float tumble;

    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (GameController.currentLevel.IsRotate())
        {
            rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
        }
        else
        {
            rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
