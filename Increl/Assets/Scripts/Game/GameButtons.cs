using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    public GameObject G_ToMainText;
    public static GameButtons G_GameButtonsClass;
    public static Text T_ToMainText;
    public GameObject G_ToMainButton;
    public static Button B_ToMainButton;
    public GameObject G_RestartButton;
    public static Image I_RestartButton;
    public static Button B_RestartButton;
    private void Awake()
    {
        G_GameButtonsClass = this;
        I_RestartButton = gameObject.GetComponent<Image>();
        B_RestartButton = gameObject.GetComponent<Button>();
        B_ToMainButton = G_ToMainButton.GetComponent<Button>();
        T_ToMainText = G_ToMainText.GetComponent<Text>();
    }
    private void Start()
    {
        I_RestartButton.color = new Color32(255, 255, 255, 0);
        B_RestartButton.enabled = false;
        B_ToMainButton.enabled = false;
    }
    public void OnRestartButton()
    {
        StartCoroutine(I_OnRestartButtonCur());
    }
    public IEnumerator I_OnRestartButtonCur()
    {
        SoundManagerGame.V_PlaySoundRestartGame();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnMainButton()
    {
        StartCoroutine(I_OnMaintButtonCur());
    }
    public IEnumerator I_OnMaintButtonCur()
    {
        SoundManagerGame.V_PlaySoundToHome();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Main");
    }
    public static IEnumerator I_RestartButtonCur(byte C_ToColor, float F_OverTime)
    {
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            I_RestartButton.color = Color32.Lerp(
                a: I_RestartButton.color,
                b: new Color32((byte)(I_RestartButton.color.r * 255), (byte)(I_RestartButton.color.g * 255), (byte)(I_RestartButton.color.b * 255), C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        I_RestartButton.color = new Color32((byte)(I_RestartButton.color.r * 255), (byte)(I_RestartButton.color.g * 255), (byte)(I_RestartButton.color.b * 255), C_ToColor);
        B_RestartButton.enabled = true;
        B_ToMainButton.enabled = true;
        G_GameButtonsClass.StartCoroutine(I_Timer());
    }
    public static IEnumerator I_Timer()
    {
        yield return new WaitForSeconds(5);
        G_GameButtonsClass.StartCoroutine(I_ToMainTextCur(255, 3f));
    }
    public static IEnumerator I_ToMainTextCur(byte C_ToColor, float F_OverTime)
    {
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            T_ToMainText.color = Color32.Lerp(
                a: T_ToMainText.color,
                b: new Color32((byte)(T_ToMainText.color.r * 255), (byte)(T_ToMainText.color.g * 255), (byte)(T_ToMainText.color.b * 255), C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        T_ToMainText.color = new Color32((byte)(T_ToMainText.color.r * 255), (byte)(T_ToMainText.color.g * 255), (byte)(T_ToMainText.color.b * 255), C_ToColor);
    }
}
