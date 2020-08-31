using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
public class Ball_Controller : MonoBehaviour
{
    public GameObject G_MaxScale;
    private GameObject G_LevelCircle; //Circle
    private int I_Random; //To find random circle
    public GameObject[] G_Circle; //Circle for all level
    public static int level; //Level
    public static string S_Happened; //What happened(Win, Die or Middle)
    public GameObject G_Ball; //This object(for static void)
    public static Transform T_BallTransform; //To change scale in static void
    private float F_Speed = 0; //Speed do ball bigger when touch
    private float F_SpeedValue; //Speed whaw ball do bigger;
    public static bool B_Second; //False when ball bigger than target(circle) => player lose
    public static bool B_First; //Trrue when ball smoller than target(circle) => player can win
    public void Start()
    {
        T_BallTransform = gameObject.GetComponent<Transform>();
        level = 1; //First level must be first :)
        V_NewLevel();
        S_Happened = "nope"; //This is the start value of this variable
        //T_BallTransform = G_Ball.GetComponent<Transform>();
        F_SpeedValue = 0.00005f;//U need to change this(If level big this beed be bigger)
    }
    void Update()
    {
        transform.position = new Vector3(GameController.F_X, GameController.F_Y, transform.position.z); //Ball will be do bigger into the circle, near the Touch
        if (Touch.S_Touch == "true" && !B_Second)
        {
            //Do ball bigger
            F_Speed += F_SpeedValue;
            transform.localScale = new Vector3(transform.localScale.y + F_Speed, transform.localScale.y + F_Speed);
        }
        //What happened (haw big ball when pleyer stop do it bigger)
        if (Touch.S_Touch == "false" && !B_First && !B_Second)
        {
            Touch.S_Touch = "nope";
            S_Happened = "middle";
            print("midle");
        }
        if (Touch.S_Touch == "false" && B_First && !B_Second)
        {
            level++;
            if (level <= 100)
            {
                F_SpeedValue += 0.000003f;
            }
            Touch.S_Touch = "nope";
            S_Happened = "win";
            print("win");
            V_NewLevel();
        }
        if ((Touch.S_Touch == "false" && B_Second) || B_Second)
        {
            Touch.S_Touch = "nope";
            S_Happened = "lose";
            print("lose");
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //To know haw big ball(to know when player die or won)
        if (collision.gameObject.CompareTag("CircleDiePlase"))
        {
            B_Second = true;
            print(collision + " DiePlase");
        }
        if (collision.gameObject.CompareTag("CircleWinPlase"))
        {
            B_First = true;
            print(collision + " WinPlase");
        }
    }
    public void V_NewLevel()
    {
        //find random circle(level affect)
        if (Mathf.CeilToInt(level / 10f) - 3f >= 0) //If "level" (level / 10) >= 3
        {
            I_Random = Random.Range(Mathf.CeilToInt((level / 10f) - 3f) * (G_Circle.Length / 10), Mathf.CeilToInt(level / 10f) * (G_Circle.Length / 10));
        }
        else if (Mathf.CeilToInt(level / 10f) - 3f < 0) //If "level" (level / 10) < 3
        {
            I_Random = Random.Range(0, Mathf.CeilToInt(level / 10f) * (G_Circle.Length / 10));
            print(Mathf.CeilToInt(level / 10f) + " " + level + " " + (level / 10f));
        }
        //print("test " + G_CloneCircle.transform.position.z + " random" + I_Random);                   //
        if (level > 1)
        {
            Destroy(G_LevelCircle);
        }
        G_LevelCircle = Instantiate(G_Circle[I_Random]);
        G_LevelCircle.transform.localScale = new Vector3(G_MaxScale.transform.localScale.x, G_MaxScale.transform.localScale.y, G_MaxScale.transform.localScale.z);
        //If u will not change this speed for do ball bigger will be more bigger every level (level doesnt affect)
        F_Speed = 0f;
        //Spawn random circle
        G_LevelCircle.transform.position = new Vector3
            (GameController.F_X, GameController.F_Y, 5f);
        //For new level u need do value of collider like this
        T_BallTransform.localScale = new Vector2(0f, 0f);
        B_Second = false;
        B_First = false;
    }
}
