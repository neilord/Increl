using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    public Text T_Total; //To show player record
    private void Awake()
    {
        T_Total = gameObject.GetComponent<Text>();
    }
    private void Start()
    {
        string S_TotalString = PlayerPrefs.GetInt("I_Total").ToString(); //Unity can show only string (to convert int(money) to string)
        T_Total.text = "Total: " + S_TotalString;
    }
}
