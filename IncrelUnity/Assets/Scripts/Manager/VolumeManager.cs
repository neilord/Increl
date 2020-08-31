using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Image I_VolumeImage;
    public Sprite Mute;
    public Sprite UnMute;
    private static int Volume = 0;
    public void VolumeChange()
    {
        PlayerPrefs.SetInt("I_Volume", PlayerPrefs.GetInt("I_Volume") + 1);
        //Volume++;
        if (PlayerPrefs.GetInt("I_Volume") % 2 == 0)
        {
            SoundManager.F_Volume = 1f;
            I_VolumeImage.sprite = UnMute;
        }
        else
        {
            SoundManager.F_Volume = -10;
            I_VolumeImage.sprite = Mute;
        }
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("I_Volume") % 2 == 0)
        {
            SoundManager.F_Volume = 1;
            I_VolumeImage.sprite = UnMute;
        }
        else
        {
            SoundManager.F_Volume = -10;
            I_VolumeImage.sprite = Mute;
        }
    }
}
