using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreAnimator : MonoBehaviour {
    
    private float moveSpeed;
    private float alphaValue;

    private TextMesh text;
    void Start()
    {
        moveSpeed = 0.8f;
        alphaValue = 1.0f;
        text = gameObject.GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alphaValue <= 0.0f)
        {
            text.transform.Translate(new Vector2(0, 0));
            Destroy(gameObject);
        }
        else
        {
            text.transform.Translate(new Vector2(0, moveSpeed) * Time.deltaTime);

            alphaValue -= Time.deltaTime;

            text.color = new Color(text.color.r, text.color.g, text.color.b, alphaValue);
        }
    }

}
