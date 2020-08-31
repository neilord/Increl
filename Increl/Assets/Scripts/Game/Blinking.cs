using UnityEngine;
using UnityEngine.UI;
using System.Collections;

class Blinking : MonoBehaviour
{
    public static bool B_Stop;
    public static float F_Speed = 0.7f;
    void Start()
    {
        B_Stop = true;
        StartCoroutine(c_Blinking(GetComponent<Text>()));
    }

    public static IEnumerator c_Blinking(Text image)
    {
        Color c = image.color;

        float alpha = 1;

        while (B_Stop)
        {
            c.a = Mathf.MoveTowards(c.a, alpha, Time.deltaTime * F_Speed);

            image.color = c;

            if (c.a == alpha)
            {
                if (alpha == 1f)
                {
                    alpha = 0.2f;
                }
                else
                    alpha = 1f;
            }

            yield return null;
        }
    }
}