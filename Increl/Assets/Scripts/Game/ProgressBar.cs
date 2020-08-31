using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour //U use this script for do something with scene(chenge it)
{
    public static float F_speed = 0.1f; //Start Speed
    public GameObject G_Fill; //To do something with fill
    public static Image I_EdgeFillAmount; //To change amount
    private void Awake()
    {
        I_EdgeFillAmount = G_Fill.GetComponent<Image>();
        I_EdgeFillAmount.fillAmount = 0f;
    }
    private void Start()
    {
        F_speed = 0.1f;
    }
    void Update()
    {
        if (Ball_Controller.B_Lose)
        {
            I_EdgeFillAmount.fillAmount += F_speed * Time.deltaTime; //timer
            if (I_EdgeFillAmount.fillAmount >= 1) //player will die
            {
                SoundManagerGame.V_PlaySoundLose();
                Ball_Controller.I_AdShow++;
                if (Advertisement.IsReady() && Ball_Controller.I_AdShow % 5 == 0)
                {
                    Advertisement.Show();
                }
                Ball_Controller.B_Lose = false;
                GameController.V_AdMoney();
                print("test Bar");
                StartCoroutine(LoseEffect.I_LoseEffect(
                    C_FromColor: new Color32(0, 0, 0, 0),
                    C_ToColor: new Color32(0, 0, 0, 113),
                    F_OverTime: 1f));
                StartCoroutine(GameButtons.I_RestartButtonCur(
                    C_ToColor: 203,
                    F_OverTime: 1));
                StartCoroutine(AdTotalCoinText.I_AdCoinCur(
                    C_ToColor: 203,
                    F_OverTime: 1));
            }
        }
    }
    public static void V_Win()
    {
        I_EdgeFillAmount.fillAmount = 0f;
        if (F_speed <= 0.5)
        {
            F_speed += 0.004f;
        }
    }
}
