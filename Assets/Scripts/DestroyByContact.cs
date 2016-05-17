using UnityEngine;
using System.Collections;
using System.Linq;

public class DestroyByContact : MonoBehaviour
{
    public GameObject enemyExplosion;
    public GameObject wrongBulletExplosion;
    public GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("DCM - Cannot find 'Game Controller' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (other.tag == "Bolt")
        {
            if (gameObject.GetComponent<EnemyController>().isTarget)
            {
                string answer = other.gameObject.GetComponentInChildren<TextMesh>().text;
                string question = gameObject.GetComponentInChildren<TextMesh>().text;
                if (GameController.getQuestion(answer).Equals(question))
                {
                    gameController.AddScore(10);
                    Destroy(gameObject);
                    Instantiate(enemyExplosion, transform.position, transform.rotation);
                }
            }
            Destroy(other.gameObject);
            Instantiate(wrongBulletExplosion, transform.position, transform.rotation);
        }

        if (other.tag == "Barrier")
        {
            gameController.MinusScore(5);
            Destroy(gameObject);
            Instantiate(enemyExplosion, transform.position, transform.rotation);
        }
    }

}
