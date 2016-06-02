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
                speed = speed*1.6f;
                transform.Find("particle").GetComponent<ParticleSystem>().Play();
                transform.Find("enemy_label").GetComponent<TextMesh>().color = Color.green;
            }
            else
            {
                transform.Find("particle").GetComponent<ParticleSystem>().Clear();
            }
        }
        GetComponent<Rigidbody>().velocity = transform.forward*speed;
    }
}
