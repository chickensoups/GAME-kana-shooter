using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour
{
    public float speed;

    void Start()
    {
        if (GameController.currentLevel.IsFaster())
        {
            float randValue = Random.value;
            if (randValue > 0.5f)
            {
                speed = speed * 2;
                GetComponentInParent<TrailRenderer>().enabled = true;
                transform.Find("enemy_label").GetComponent<TextMesh>().color = Color.green;
            }
        }
        GetComponent<Rigidbody>().velocity = transform.forward*speed;
    }
}
