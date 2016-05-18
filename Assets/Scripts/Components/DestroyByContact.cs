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
                if (GameController.GetQuestion(answer).Equals(question))
                {
                    gameController.AddScore(70);
                    Destroy(gameObject);
                    Instantiate(enemyExplosion, transform.position, transform.rotation);
                }
                else
                {
                    gameController.MinusScore(1);
                    Instantiate(wrongBulletExplosion, transform.position, transform.rotation);
                }
            }
            Destroy(other.gameObject);
        }

        if (other.tag == "Barrier")
        {
            gameController.MinusScore(70);
            Destroy(gameObject);
            Instantiate(enemyExplosion, transform.position, transform.rotation);
        }
    }

}
