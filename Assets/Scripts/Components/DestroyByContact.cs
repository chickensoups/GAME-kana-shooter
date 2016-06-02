using UnityEngine;
using System.Collections;
using System.Linq;

public class DestroyByContact : MonoBehaviour
{
    public GameObject enemyExplosion;
    public GameObject wrongBulletExplosion;
    public GameController gameController;
    public GameObject scoreAnimationText;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("DCM - Can't find 'Game Controller' script");
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
                    gameController.AddScore(Constants.RIGHT_BOLT_ADD_SCORE);
                    Destroy(gameObject);
                    Instantiate(enemyExplosion, transform.position, transform.rotation);
                    GameObject scoreTextAnimation = (GameObject) Instantiate(scoreAnimationText, transform.position, Quaternion.identity);
                    scoreTextAnimation.GetComponentInChildren<TextMesh>().color = Color.red;
                    scoreTextAnimation.GetComponentInChildren<TextMesh>().text = "+" + Constants.RIGHT_BOLT_ADD_SCORE;
                }
                else
                {
                    gameController.MinusScore(Constants.WRONG_BOLT_MINUS_SCORE);
                    Instantiate(wrongBulletExplosion, transform.position, transform.rotation);
                    GameObject scoreTextAnimation = (GameObject)Instantiate(scoreAnimationText, transform.position, Quaternion.identity);
                    scoreTextAnimation.GetComponentInChildren<TextMesh>().text = "-" + Constants.WRONG_BOLT_MINUS_SCORE;
                }
            }
            Destroy(other.gameObject);
        }

        if (other.tag == "Barrier")
        {
            gameController.MinusScore(Constants.ENEMY_TOUCHE_BARRIER_MINUS_SCORE);
            Destroy(gameObject);
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            GameObject scoreTextAnimation = (GameObject)Instantiate(scoreAnimationText, transform.position, Quaternion.identity);
            scoreTextAnimation.GetComponentInChildren<TextMesh>().text = "-" + Constants.ENEMY_TOUCHE_BARRIER_MINUS_SCORE;
        }
    }

}
