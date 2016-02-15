//Author Jesse Stam
//Created 15-2-2016
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour {

    public event VoidDelegate onClose;

    private Slider SFXVolume, MusicVolume;
    private Toggle FullScreen;

	public void OpenMenu()
    {

    }

    public void CloseMenu()
    {
        if (onClose != null)
            onClose();
    }

    public void MusicVolumeChange(float f)
    {

    }

    public void SFXVolumeChange(float f)
    {

    }

    public void FullScreenChange(bool b)
    {

    }
}
