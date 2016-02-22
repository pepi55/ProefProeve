﻿//Author Jesse Stam
//Created 15-2-2016

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour {

    public event VoidDelegate onClose;
    [SerializeField]
    private Slider SFXVolume = null, MusicVolume = null;
    [SerializeField]
    private Toggle FullScreen = null, Vsync = null;
    [SerializeField]
    private ResolutionSelector resolutionSelector = null;

    [SerializeField]
    OptionSaveData data;

    void Start()
    {
        init();
    }

    void init()
    {
        try
        {
            Util.Serialization.Load("OptionData", Util.Serialization.fileTypes.binary, ref data);

            if (data == null)
            {
                data = new OptionSaveData();
                Util.Serialization.Save("OptionData", Util.Serialization.fileTypes.binary, data);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
            Debug.Log(data);
            Util.Debugger.Log("Expetion loading data", e.Message);
        }

        try
        {
            SFXVolume.value = data.SFXVolume;
            MusicVolume.value = data.MusicVolume;

            FullScreen.isOn = data.useFullScreen;
            Vsync.isOn = data.Vsync;

            if (data.ResolutionIndex != -1 && data.screenHeight != -1 && data.screenWidth != -1)
            {
                resolutionSelector.dropdown.value = data.ResolutionIndex;
            }
        }
        catch (System.Exception e)
        {
            Util.Debugger.Log("Exeption Assigning data", e);//.Message + "/n" + e.Source + "/n" + e.StackTrace);
            Util.Debugger.Log("Exception Assinging Data Value", data);
        }
    }

	public void OpenMenu()
    {
        init();
        gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        if (onClose != null)
            onClose();

        gameObject.SetActive(false);
    }

    public void SaveData()
    {
        if (!Application.isEditor)
        {
            Resolution r = resolutionSelector.getCurrentResolution();
            Screen.SetResolution(r.width, r.height, FullScreen.isOn);
        }

        QualitySettings.vSyncCount = data.Vsync ? 1 : 0;    

        if (data == null)
        {
            data = new OptionSaveData();   
        }
        Util.Serialization.Save("OptionData", Util.Serialization.fileTypes.binary, data);
    }

    public void MusicVolumeChange(float f)
    {
        data.MusicVolume = f;
    }

    public void SFXVolumeChange(float f)
    {
        data.SFXVolume = f;
    }

    public void FullScreenChange(bool b)
    {
        data.useFullScreen = b;
    }

    public void OnResolutionChange(int i)
    {
        Resolution r = resolutionSelector.getCurrentResolution();
        data.screenWidth = r.width;
        data.screenHeight = r.height;
        data.ResolutionIndex = i;
    }

    public void OnVsyncChange(bool b)
    {
        data.Vsync = b;
    }
}
