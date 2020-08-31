using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    public Text T_Record; //To show player record
    private void Awake()
    {
        //PlayerPrefs.SetInt("I_Record", 1);
        T_Record = gameObject.GetComponent<Text>();
    }
    private void Start()
    {
        //PlayerPrefs.SetInt("I_Record", 1);
        string S_RecordString = PlayerPrefs.GetInt("I_Record").ToString(); //Unity can show only string (to convert int(money) to string)
        T_Record.text = "Best: " + S_RecordString;
    }
}
