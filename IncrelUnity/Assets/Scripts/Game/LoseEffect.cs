using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseEffect : MonoBehaviour
{
    public static float F_Speed = 1f;
    public static Image I_LoseEffectImage;
    private void Awake()
    {
        I_LoseEffectImage = GetComponent<Image>();
    }
    void Start()
    {
        I_LoseEffectImage.color = new Color32(0, 0, 0, 0);
    }
    public static IEnumerator I_LoseEffect(Color32 C_FromColor, Color32 C_ToColor, float F_OverTime)
    {
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            I_LoseEffectImage.color = Color32.Lerp(
                a: C_FromColor,
                b: C_ToColor,
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        I_LoseEffectImage.color = C_ToColor;
    }
}
