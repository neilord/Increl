using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class Ball_Controller : MonoBehaviour
{
    #region values
    public static int I_AdShow = 0;
    private bool B_SpawnEffect = false; //First circle will spawn slowly then another
    public static bool B_Lose; //To know when player lose
    private float F_Screen; //Smollest size of screen
    private bool B_IsScale = false; //To know need u move it or not
    private Vector3 V_LocalScale; //Circle Scale
    private const float F_SpeedScale = 5; //Speed how cirle will be bigger
    public static int I_WhenMoveCircle = 25; //To know after what level u need move circle
    private float F_RandomScale; //Random scale for circle
    public static GameObject G_LevelCircle; //Circle
    private int I_Random; //To find random circle
    public GameObject[] G_Circle; //Circle for all level
    public static int I_level = 1; //Level
    public static Transform T_BallTransform; //To change scale in static void
    private float F_Speed = 0; //Speed do ball bigger when touch
    private float F_SpeedValue = 0.00005f; //Speed how ball do bigger;
    public static bool B_Second; //False when ball bigger than target(circle) => player lose
    public static bool B_First; //True when ball smoller than target(circle) => player can win
    #endregion
    private void Awake()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3680181", false);
        }
        else
        {
            Debug.Log("Platform is not supported");
        }
        B_SpawnEffect = false;
        T_BallTransform = gameObject.GetComponent<Transform>();
        if (Screen.width > Screen.height) //To know what is the bigest side (height or width)
        {
            F_Screen = Screen.height;
        }
        else
        {
            F_Screen = Screen.width;
        }
    }
    public void Start()
    {
        //For new level(restart)
        Touch.S_Touch = "nope";
        B_First = true;
        B_Second = true;
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        B_SpawnEffect = true;
        B_Lose = true;
        I_level = 1;
        LevelText.ChangeLevelText();
        F_Speed = 0;
        F_SpeedValue = 0.00005f;
        B_IsScale = false;
        V_NewLevel();
    }
    void Update()
    {
        transform.position = new Vector3(x: GameController.F_X, y: GameController.F_Y, z: transform.position.z); //Ball will be do bigger into the circle, near the Touch
        #region hold
        if (B_Lose)
        {
            if (Touch.S_Touch == "true" && !B_Second)
            {
                //Do ball bigger
                F_Speed += F_SpeedValue;
                transform.localScale = new Vector2(x: transform.localScale.y + F_Speed, y: transform.localScale.y + F_Speed);
            }

            //What happened (haw big ball when pleyer stop do it bigger)
            if (Touch.S_Touch == "false" && !B_First && !B_Second) //Middle
            {
                SoundManagerGame.V_PlaySoundLose();
                I_AdShow++;
                if (Advertisement.IsReady() && I_AdShow % 5 == 0)
                {
                    Advertisement.Show();
                }
                print("test Middle");
                Touch.S_Touch = "nope";
                GameController.V_AdMoney();
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
                B_Lose = false;
            }
            if (Touch.S_Touch == "false" && B_First && !B_Second) //Win
            {
                SoundManagerGame.V_PlaySoundPassLevel();
                LevelText.ChangeLevelText();
                print("test Win");
                Touch.S_Touch = "nope";
                I_level++;
                LevelText.ChangeLevelText();
                V_NewLevel();
                if (I_level >= I_WhenMoveCircle) //If level >= level after what value u d'like to move circle
                {
                    GameController.I_NewPos(
                        width: Random.Range(                                                          //Random range X
                        (Screen.width / 128.113f / 2 * -1) + (F_RandomScale * 3.25f),                         //From(smoller)
                        (Screen.width / 128.113f / 2) - (F_RandomScale * 3.25f)),                             //To(bigger)
                        height: Random.Range(                                                          //Random range Y
                        (Screen.height / 128 / 2 * -1) + (F_RandomScale * 3.25f),                         //From(smoller)
                        (Screen.height / 128 / 2) - (F_RandomScale * 3.25f)));                            //To(bigger)
                }
                if (I_level <= 100)
                {
                    F_SpeedValue += 0.000003f;
                }
                ProgressBar.V_Win();
            }
            if ((Touch.S_Touch == "false" && B_Second) || B_Second) //Lose
            {
                SoundManagerGame.V_PlaySoundLose();
                I_AdShow++;
                if (Advertisement.IsReady() && I_AdShow % 5 == 0)
                {
                    Advertisement.Show();
                }
                print("test Lose");
                Touch.S_Touch = "nope";
                GameController.V_AdMoney();
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
                B_Lose = false;
            }
            if (Touch.S_Touch == "exit") //Exit
            {
                SoundManagerGame.V_PlaySoundLose();
                I_AdShow++;
                if (Advertisement.IsReady() && I_AdShow %5 == 0)
                {
                    Advertisement.Show();
                }
                print("test Exit");
                Touch.S_Touch = "nope";
                GameController.V_AdMoney();
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
                B_Lose = false;
            }
        }
        #endregion
        if (B_IsScale)
        {
            G_LevelCircle.transform.localScale = Vector3.Lerp(
                a: V_LocalScale,
                b: G_LevelCircle.transform.localScale = new Vector3(F_RandomScale, F_RandomScale, transform.localScale.z),
                t: Time.deltaTime * F_SpeedScale);
            V_LocalScale = new Vector3(G_LevelCircle.transform.localScale.x, G_LevelCircle.transform.localScale.x, G_LevelCircle.transform.localScale.x);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //To know haw big ball(to know when player die or won)
        if (collision.gameObject.CompareTag("CircleDiePlase"))
        {
            B_Second = true;
        }
        if (collision.gameObject.CompareTag("CircleWinPlase"))
        {
            B_First = true;
        }
    }
    private void V_NewLevel() //Spawn new circle, do ball less
    {
        //find random circle(level affect)
        if (Mathf.CeilToInt(I_level / 10f) - 3f >= 0) //If "level" (level / 10) >= 3
        {
            I_Random = Random.Range(Mathf.CeilToInt((I_level / 10f) - 3f) * (G_Circle.Length / 10), Mathf.CeilToInt(I_level / 10f) * (G_Circle.Length / 10));
        }
        else if (Mathf.CeilToInt(I_level / 10f) - 3f < 0) //If "level" (level / 10) < 3
        {
            I_Random = Random.Range(0, Mathf.CeilToInt(I_level / 10f) * (G_Circle.Length / 10));
        }
        if (I_level > 1)
        {
            B_IsScale = true;
            Destroy(G_LevelCircle);
        }
        G_LevelCircle = Instantiate(G_Circle[I_Random]);
        if (B_SpawnEffect)
        {
            G_LevelCircle.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
            StartCoroutine(I_SpawnEffect(255, 1, G_LevelCircle.GetComponent<SpriteRenderer>()));
        }
        Touch.B_CanTouch = true;
        F_RandomScale = Random.Range(F_Screen / 2000f, F_Screen / 847f);
        if (I_level == 1)
        {
            G_LevelCircle.transform.localScale = new Vector3(F_RandomScale, F_RandomScale, transform.localScale.z);
            V_LocalScale = new Vector3(
                x: G_LevelCircle.transform.localScale.x,
                y: G_LevelCircle.transform.localScale.x,
                z: G_LevelCircle.transform.localScale.x);
        }
        F_Speed = 0f; //If u will not change this speed for do ball bigger will be more bigger every level (level doesnt affect)
        G_LevelCircle.transform.position = new Vector3         //Spawn random circle
            (x: GameController.F_X, y: GameController.F_Y, z: 5f);
        T_BallTransform.localScale = new Vector2(0f, 0f);
        B_Second = false;
        B_First = false;
    }
    private IEnumerator I_SpawnEffect(byte C_ToColor, float F_OverTime, SpriteRenderer C_SpawnEffect)
    {
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            C_SpawnEffect.color = Color32.Lerp(
                a: C_SpawnEffect.color,
                b: new Color32((byte)(C_SpawnEffect.color.r * 255), (byte)(C_SpawnEffect.color.g * 255), (byte)(C_SpawnEffect.color.b * 255), C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        C_SpawnEffect.color = new Color32((byte)(C_SpawnEffect.color.r * 255), (byte)(C_SpawnEffect.color.g * 255), (byte)(C_SpawnEffect.color.b * 255), C_ToColor);
        B_SpawnEffect = false;
    }
}
