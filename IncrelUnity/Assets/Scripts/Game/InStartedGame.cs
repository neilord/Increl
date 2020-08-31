using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InStartedGame : MonoBehaviour
{
    public byte EffectTime;
    public Image I_Fill;
    public Image I_Edge;
    public Text T_LevelText;
    private byte B_ValueEffect;
    private byte B_FillValueEffect;
    private void Awake()
    {
        B_ValueEffect = 255;
        B_FillValueEffect = 210;
    }
    public void Start()
    {
        StartCoroutine(I_InStartedGameFill(
            C_ToColor: B_FillValueEffect,
            F_OverTime: EffectTime));
        StartCoroutine(I_InStartedGameEdge(
            C_ToColor: B_ValueEffect,
            F_OverTime: EffectTime));
        StartCoroutine(I_InStartedGameLevelText(
            C_ToColor: B_ValueEffect,
            F_OverTime: EffectTime));
    }
    private IEnumerator I_InStartedGameFill(byte C_ToColor, float F_OverTime)
    {
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            I_Fill.color = Color32.Lerp(
                a: I_Fill.color,
                b: new Color32((byte)(I_Fill.color.r * 255), (byte)(I_Fill.color.g * 255), (byte)(I_Fill.color.b * 255), C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        I_Fill.color = new Color32((byte)(I_Fill.color.r * 255), (byte)(I_Fill.color.g * 255), (byte)(I_Fill.color.b * 255), C_ToColor);
    }
    private IEnumerator I_InStartedGameEdge(byte C_ToColor, float F_OverTime)
    {
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            I_Edge.color = Color32.Lerp(
                a: I_Edge.color,
                b: new Color32((byte)(I_Edge.color.r * 255), (byte)(I_Edge.color.g * 255), (byte)(I_Edge.color.b * 255), C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        I_Edge.color = new Color32((byte)(I_Edge.color.r * 255), (byte)(I_Edge.color.g * 255), (byte)(I_Edge.color.b * 255), C_ToColor);
    }
    private IEnumerator I_InStartedGameLevelText(byte C_ToColor, float F_OverTime)
    {
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            T_LevelText.color = Color32.Lerp(
                a: T_LevelText.color,
                b: new Color32((byte)(T_LevelText.color.r * 255), (byte)(T_LevelText.color.g * 255), (byte)(T_LevelText.color.b * 255), C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        T_LevelText.color = new Color32((byte)(T_LevelText.color.r * 255), (byte)(T_LevelText.color.g * 255), (byte)(T_LevelText.color.b * 255), C_ToColor);
    }
}
