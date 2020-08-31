using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public static StartGame S_StartGameClass;
    public GameObject G_SoundImage;
    public GameObject G_TotalText;
    public GameObject G_PlayText;
    public GameObject G_BestText;
    public static Image I_SoundImage;
    public static Text T_TotalText;
    public static Text T_PlayText;
    public static Text T_BestText;
    public static byte B_ValueEffect;
    private void Awake()
    {
        B_ValueEffect = 0;
        S_StartGameClass = this;
        I_SoundImage = G_SoundImage.GetComponent<Image>();
        T_TotalText = G_TotalText.GetComponent<Text>();
        T_PlayText = G_PlayText.GetComponent<Text>();
        T_BestText = G_BestText.GetComponent<Text>();
    }
    public static void V_StartGame()
    {
        S_StartGameClass.StartCoroutine(I_StartGameSound(
            C_ToColor: B_ValueEffect,
            F_OverTime: 1f));
        S_StartGameClass.StartCoroutine(I_StartGamePlay(
            C_ToColor: B_ValueEffect,
            F_OverTime: 1f));
        S_StartGameClass.StartCoroutine(I_StartGameBest(
                    C_ToColor: B_ValueEffect,
                    F_OverTime: 1f));
        S_StartGameClass.StartCoroutine(I_StartGameTotal(
            C_ToColor: B_ValueEffect,
            F_OverTime: 1f));
        SoundManager.V_PlaySoundStartGame();
    }
    public static IEnumerator I_StartGamePlay(byte C_ToColor, float F_OverTime)
    {
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            T_PlayText.color = Color32.Lerp(
                a: T_PlayText.color,
                b: new Color32((byte)T_PlayText.color.r, (byte)T_PlayText.color.g, (byte)T_PlayText.color.b, C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        T_PlayText.color = new Color32((byte)T_PlayText.color.r, (byte)T_PlayText.color.g, (byte)T_PlayText.color.b, C_ToColor);
    }
    public static IEnumerator I_StartGameBest(byte C_ToColor, float F_OverTime)
    {
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            T_BestText.color = Color32.Lerp(
                a: T_BestText.color,
                b: new Color32((byte)T_BestText.color.r, (byte)T_BestText.color.g, (byte)T_BestText.color.b, C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        T_BestText.color = new Color32((byte)T_BestText.color.r, (byte)T_BestText.color.g, (byte)T_BestText.color.b, C_ToColor);
        SceneManager.LoadScene("Game");
    }
    public static IEnumerator I_StartGameTotal(byte C_ToColor, float F_OverTime)
    {
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            T_TotalText.color = Color32.Lerp(
                a: T_TotalText.color,
                b: new Color32((byte)T_TotalText.color.r, (byte)T_TotalText.color.g, (byte)T_TotalText.color.b, C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        T_TotalText.color = new Color32((byte)T_TotalText.color.r, (byte)T_TotalText.color.g, (byte)T_TotalText.color.b, C_ToColor);
        SceneManager.LoadScene("Game");
    }
    public static IEnumerator I_StartGameSound(byte C_ToColor, float F_OverTime)
    {
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            I_SoundImage.color = Color32.Lerp(
                a: I_SoundImage.color,
                b: new Color32((byte)I_SoundImage.color.r, (byte)I_SoundImage.color.g, (byte)I_SoundImage.color.b, C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        I_SoundImage.color = new Color32((byte)I_SoundImage.color.r, (byte)I_SoundImage.color.g, (byte)I_SoundImage.color.b, C_ToColor);
        SceneManager.LoadScene("Game");
    }
}
