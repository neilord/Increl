using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerGame : MonoBehaviour
{
    public AudioClip A_PublicLose;
    public AudioClip A_PublicNewBest;
    public AudioClip A_PublicPassLevel;
    public AudioClip A_PublicToHome;
    public AudioClip A_PublicRestartGame;
    public static AudioClip A_Lose;
    public static AudioClip A_NewBest;
    public static AudioClip A_PassLevel;
    public static AudioClip A_RestartGame;
    public static AudioClip A_ToHome;
    public GameObject G_GameSound;
    public static AudioSource A_GameSource;
    private void Awake()
    {
        A_GameSource = G_GameSound.GetComponent<AudioSource>();
        A_NewBest = A_PublicNewBest;
        A_PassLevel = A_PublicPassLevel;
        A_RestartGame = A_PublicRestartGame;
        A_ToHome = A_PublicToHome;
        A_Lose = A_PublicLose;
    }
    public static void V_PlaySoundRestartGame()
    {
        A_GameSource.PlayOneShot(A_RestartGame, SoundManager.F_Volume);
    }
    public static void V_PlaySoundToHome()
    {
        A_GameSource.PlayOneShot(A_ToHome, SoundManager.F_Volume + 0.2f);
    }
    public static void V_PlaySoundPassLevel()
    {
        A_GameSource.PlayOneShot(A_PassLevel, SoundManager.F_Volume + 0.5f);
    }
    public static void V_PlaySoundNewBest()
    {
        A_GameSource.PlayOneShot(A_NewBest, SoundManager.F_Volume + 0.0f);
    }
    public static void V_PlaySoundLose()
    {
        A_GameSource.PlayOneShot(A_Lose, SoundManager.F_Volume + 0.0f);
    }
}
