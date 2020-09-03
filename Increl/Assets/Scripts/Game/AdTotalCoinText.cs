using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdTotalCoinText : MonoBehaviour
{
    public static AdTotalCoinText A_AdTotalCoinTextClass;
    public GameObject G_AdCoin;
    public static Text T_AdCoin;
    private void Awake()
    {
        A_AdTotalCoinTextClass = this;
        T_AdCoin = G_AdCoin.GetComponent<Text>();
    }
    public static IEnumerator I_AdCoinCur(byte C_ToColor, float F_OverTime)
    {
        T_AdCoin.text = "+ " + Ball_Controller.I_level;
        yield return new WaitForSeconds(1);
        float F_StartTime = Time.time;
        while (Time.time < F_StartTime + F_OverTime)
        {
            T_AdCoin.color = Color32.Lerp(
                a: T_AdCoin.color,
                b: new Color32((byte)(T_AdCoin.color.r * 255), (byte)(T_AdCoin.color.g * 255), (byte)(T_AdCoin.color.b * 255), C_ToColor),
                t: (Time.time - F_StartTime) / F_OverTime);
            yield return null;
        }
        T_AdCoin.color = new Color32((byte)(T_AdCoin.color.r * 255), (byte)(T_AdCoin.color.g * 255), (byte)(T_AdCoin.color.b * 255), C_ToColor);
    }
}