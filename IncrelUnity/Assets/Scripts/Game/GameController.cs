using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject G_RecordText;
    public static GameController G_GameControllerClass;
    public static Text T_RecordText;
    public static float F_SWidth; //X position(when circle must move)
    public static float F_SHeight; //Y position(when circle must move)
    private const float F_Speed = 0.7f; //Speed
    public static Transform T_GameController;
    public static float F_X; //X transform position for all object for game(ball, circles, Touch)
    public static float F_Y; //Y transform position for all object for game(ball, circles, Touch)
    private void Awake()
    {
        T_RecordText = G_RecordText.GetComponent<Text>();
        G_GameControllerClass = this;
        T_GameController = gameObject.GetComponent<Transform>();
    }
    private void Update()
    {
        F_X = transform.position.x;
        F_Y = transform.position.y;
        if (Ball_Controller.I_level >= Ball_Controller.I_WhenMoveCircle)
        {
            transform.position = Vector3.Lerp(
                a: transform.position,
                b: transform.position = new Vector3(F_SWidth, F_SHeight, transform.position.z),
                t: F_Speed * Time.deltaTime);
        }
    }
    public static void I_NewPos(float width, float height)
    {
        F_SHeight = height;
        F_SWidth = width;
    }
    public static void V_AdMoney()
    {
        if (Ball_Controller.I_level > PlayerPrefs.GetInt("I_Record"))
        {
            PlayerPrefs.SetInt("I_Record", Ball_Controller.I_level);
            T_RecordText.text = "New best!\n" + Ball_Controller.I_level;
            G_GameControllerClass.StartCoroutine(I_Record(255, 1f));
            SoundManagerGame.V_PlaySoundNewBest();
        }
        PlayerPrefs.SetInt("I_Money", PlayerPrefs.GetInt("I_Money") + Mathf.FloorToInt(Ball_Controller.I_level / 10));
        PlayerPrefs.SetInt("I_Total", PlayerPrefs.GetInt("I_Total") + Ball_Controller.I_level);
    }
    public static IEnumerator I_Record(byte C_ToColor, float F_OverTime)
    {
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            T_RecordText.color = Color32.Lerp(
                a: T_RecordText.color,
                b: new Color32((byte)(T_RecordText.color.r * 255), (byte)(T_RecordText.color.g * 255), (byte)(T_RecordText.color.b * 255), C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        T_RecordText.color = new Color32((byte)(T_RecordText.color.r * 255), (byte)(T_RecordText.color.g * 255), (byte)(T_RecordText.color.b * 255), C_ToColor);
        //G_GameControllerClass.StartCoroutine(I_BlinkingSize(T_RecordText));
    }
    public static IEnumerator I_BlinkingSize(Text T_RecordText)
    {
        print(1);
        float ThisFont = T_RecordText.fontSize;

        float NextFont = 140;

        while (true)
        {
            ThisFont = (int)Mathf.MoveTowards(ThisFont, NextFont, Time.deltaTime);

            T_RecordText.fontSize = (int)ThisFont;

            if (ThisFont == NextFont)
            {
                if (NextFont == 140f)
                {
                    NextFont = 120f;
                }
                else
                    NextFont = 140f;
            }

            print(2);
            yield return null;
        }
    }
}
