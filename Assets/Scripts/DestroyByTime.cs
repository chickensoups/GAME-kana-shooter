using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
    public float expiredTime;

    void Start()
    {
        Destroy(gameObject, expiredTime);
    }
}
