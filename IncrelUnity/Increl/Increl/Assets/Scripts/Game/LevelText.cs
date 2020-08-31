using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    private string S_LevelString; //To convert int to string
    public Text T_level;
    void Start()
    {
        T_level = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        //Score(level)
        S_LevelString = Ball_Controller.level.ToString();
        T_level.text = S_LevelString;
    }
}
