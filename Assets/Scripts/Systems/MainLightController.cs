using UnityEngine;
using System.Collections;

public class MainLightController : MonoBehaviour
{

    private static Light light1;
    private static float lightUpDuration;
    private static float lightDownDuration;

    private static Color[] colors = new Color[] { Color.black, Color.blue, Color.cyan, Color.gray, Color.green, Color.magenta, Color.white, Color.yellow };

    void Start()
    {
        light1 = GetComponent<Light>();
        lightUpDuration = 20;
        lightDownDuration = 20;
    }

    public static IEnumerator LightUp()
    {
        float t = 0;
        while (t < lightUpDuration)
        {
            light1.color = colors[Random.Range(0, colors.Length - 1)];
            t++;
            float point = 0.8f;
            if (t > lightUpDuration / 2)
            {
                point = -0.8f;
            }
            light1.intensity += point;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public static IEnumerator LightDown()
    {
        float t = 0;
        while (t < lightUpDuration)
        {
            light1.color = colors[Random.Range(0, colors.Length - 1)];
            t++;
            float point = 0.8f;
            if (t > lightUpDuration / 2)
            {
                point = -0.8f;
            }
            light1.intensity += point;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
