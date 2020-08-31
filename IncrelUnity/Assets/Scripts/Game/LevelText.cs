using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public static string S_LevelString; //To convert int to string
    public static Text T_level; //Text of level
    private void Awake()
    {
        T_level = gameObject.GetComponent<Text>();
    }
    public static void ChangeLevelText()
    {
        S_LevelString = Ball_Controller.I_level.ToString();
        T_level.text = S_LevelString;
    }
}
