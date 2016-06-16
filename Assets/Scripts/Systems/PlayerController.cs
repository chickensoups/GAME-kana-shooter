using System;
using UnityEngine;
using System.Collections;
using System.Net;
using System.Xml.Schema;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;

    public GameObject bolt;
    public GameObject boltSpawn;

    public float fireRate;
    private float nextFire;

    private Vector3 targetPosition;

    void Awake()
    {
        EnemyController.TargetFound += MovePlayerToPosition;
    }

    void Start()
    {
        targetPosition = new Vector3(0.1f, 0, 0);
    }

    void Update()
    {
        //fire by fire rate
        if (WeaponController.hadTarget && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            bolt.GetComponentInChildren<TextMesh>().text =
                WeaponController.GetChoosenWeaponName();
            Instantiate(bolt, boltSpawn.transform.position, boltSpawn.transform.rotation);
            //GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        //move player
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        float distance = rigidbody.position.x - targetPosition.x;
        if (Math.Abs(distance) < 0.3)
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
            rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            rigidbody.position = new Vector3(rigidbody.position.x - distance, 0.0f, 0.0f);
        }
    }

    public void MovePlayerToPosition(GameObject newTarget)
    {
        if (newTarget != null)
        {
            targetPosition = newTarget.GetComponent<Rigidbody>().position;

        }
        else
        {
            targetPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Transform transform = GetComponent<Transform>();
        targetPosition.z = 0.0f;
        rigidbody.velocity = (targetPosition - transform.position).normalized * speed;

        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, -6, 6),
            0.0f,
            0.0f
            );

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }
}
