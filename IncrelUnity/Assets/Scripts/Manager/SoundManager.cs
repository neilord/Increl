using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip A_StartGame;
    public GameObject G_MainSound;
    public static AudioSource A_MainSource;
    public static float F_Volume = 1f;
    private void Awake()
    {
        A_MainSource = G_MainSound.GetComponent<AudioSource>();
        A_StartGame = A_MainSource.clip;
    }
    public static void V_PlaySoundStartGame()
    {
        A_MainSource.PlayOneShot(A_StartGame, F_Volume - 0.45f);
    }
}
