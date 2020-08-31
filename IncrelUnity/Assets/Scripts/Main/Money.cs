using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text T_Money; //To show player money
    private void Awake()
    {
        T_Money = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        string S_MoneyString = PlayerPrefs.GetInt("I_Money").ToString();//Unity can show only string (to convert int(money) to string)
        T_Money.text = "Maney: " + S_MoneyString;
    }
}
