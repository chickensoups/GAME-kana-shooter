using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public int labelIndex;
    public bool isTarget;

    // Use this for initialization
	void Start ()
	{
        //render text
        TextMesh[] labels = gameObject.GetComponentsInChildren<TextMesh>();
	    labelIndex = Mathf.CeilToInt(Random.value*(GameController.currentLevel.GetQuestions().Count - 1));
        string question = GameController.GetQuestion(labelIndex);
        TextMesh enemyLabel = labels[0];
	    enemyLabel.text = question;
	    if (GameController.hint)
	    {
	        string answer = GameController.GetAnswer(labelIndex);
            TextMesh hintLabel = labels[1];
            hintLabel.text = answer;
	    }
        if (!WeaponController.hadTarget)
        {
            isTarget = true;
            if (TargetFound != null)
            {
                TargetFound(gameObject);
            }
        }

        //set previous enemy id
        gameObject.GetComponent<EnemyData>().previousEnemyID = GameController.currentEnemyId;
        GameController.currentEnemyId = gameObject.GetInstanceID();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    GameObject FindNewTarget(GameObject currentTarget)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject newTarget = null;
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<EnemyData>().previousEnemyID == currentTarget.GetInstanceID())
            {
                newTarget = enemy;
                newTarget.GetComponent<EnemyController>().isTarget = true;
                break;
            }
        }
        return newTarget;
    }

    void OnDestroy()
    {
        //find new target and change weapon labels
        GameObject newTarget = FindNewTarget(gameObject); //find new target
        if (TargetFound != null)
        {
            TargetFound(newTarget);
        }
    }


    public delegate void FoundNewTarget(GameObject newTarget);

    public static event FoundNewTarget TargetFound;
}
