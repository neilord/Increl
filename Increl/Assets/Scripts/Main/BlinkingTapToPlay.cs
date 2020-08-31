using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingTapToPlay : MonoBehaviour
{
    public Text T_BlinkingTapToPlayText;
    void Start()
    {
        StartCoroutine(I_BlinkingOne(30, 5f));
    }
    public IEnumerator I_BlinkingOne(byte C_ToColor, float F_OverTime)
    {
        print(0);
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            T_BlinkingTapToPlayText.color = Color32.Lerp(
                a: T_BlinkingTapToPlayText.color,
                b: new Color32((byte)(T_BlinkingTapToPlayText.color.r), (byte)(T_BlinkingTapToPlayText.color.g), (byte)(T_BlinkingTapToPlayText.color.b), C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        print(1.2);
        T_BlinkingTapToPlayText.color = new Color32((byte)(T_BlinkingTapToPlayText.color.r * 255), (byte)(T_BlinkingTapToPlayText.color.g * 255), (byte)(T_BlinkingTapToPlayText.color.b * 255), C_ToColor);
        print(1);
    }
    public IEnumerator I_BlinkingTwo(byte C_ToColor, float F_OverTime)
    {
        print(2);
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            T_BlinkingTapToPlayText.color = Color32.Lerp(
                a: T_BlinkingTapToPlayText.color,
                b: new Color32((byte)(T_BlinkingTapToPlayText.color.r * 255), (byte)(T_BlinkingTapToPlayText.color.g * 255), (byte)(T_BlinkingTapToPlayText.color.b * 255), C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        T_BlinkingTapToPlayText.color = new Color32((byte)(T_BlinkingTapToPlayText.color.r * 255), (byte)(T_BlinkingTapToPlayText.color.g * 255), (byte)(T_BlinkingTapToPlayText.color.b * 255), C_ToColor);
        print(3);
        StartCoroutine(I_BlinkingOne(30, 1f));
    }
}
