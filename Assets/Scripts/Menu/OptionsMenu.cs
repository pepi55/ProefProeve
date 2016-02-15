//Author Jesse Stam
//Created 15-2-2016
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour {

    public event VoidDelegate onClose;
    [SerializeField]
    private Slider SFXVolume, MusicVolume;
    [SerializeField]
    private Toggle FullScreen;

    [SerializeField]
    OptionSaveData data;

    void Start()
    {
        try
        {
            util.Serialization.Load("OptionData", util.Serialization.fileTypes.binary, ref data);

            if (data == null)
            {
                data = new OptionSaveData();
                util.Serialization.Save("OptionData", util.Serialization.fileTypes.binary, data);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
            Debug.Log(data);
        }
        init();
    }

    void init()
    {
        SFXVolume.value = data.SFXVolume;
        MusicVolume.value = data.MusicVolume;

        FullScreen.isOn = data.useFullScreen;
    }

	public void OpenMenu()
    {
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
        if (data == null)
        {
            data = new OptionSaveData();   
        }
        util.Serialization.Save("OptionData", util.Serialization.fileTypes.binary, data);
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
}
