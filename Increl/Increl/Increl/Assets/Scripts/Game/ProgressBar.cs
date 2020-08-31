using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour //U use this script for do something with scene(chenge it)
{
    public float F_speed;
    public GameObject G_Fill; //To do something with fill
    public Image I_EdgeFillAmount; //To change amount
    void Start()
    {
        F_speed = 0.1f;
        I_EdgeFillAmount = G_Fill.GetComponent<Image>();
        I_EdgeFillAmount.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        I_EdgeFillAmount.fillAmount += F_speed * Time.deltaTime; //timer
        if (I_EdgeFillAmount.fillAmount >= 1) //player will die
        {
            Ball_Controller.S_Happened = "lose";
            SceneManager.LoadScene("Lose");
            print("GG");
            Ball_Controller.S_Happened = "nope";
            
        }
        if (Ball_Controller.S_Happened == "win")
        {
            if (F_speed <= 0.5)
            {
                F_speed += 0.004f;
            }
            I_EdgeFillAmount.fillAmount = 0f;
            Ball_Controller.S_Happened = "nope";
        }
        if (Ball_Controller.S_Happened == "lose")
        {
            StartCoroutine(I_LoseScene());
        }
        if (Ball_Controller.S_Happened == "middle")
        {
            StartCoroutine(I_LoseScene());
        }
    }
    public IEnumerator I_LoseScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Lose");
    }
}
