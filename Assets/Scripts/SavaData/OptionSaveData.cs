using UnityEngine;
using System.Collections;

[System.Serializable]
public class OptionSaveData
{
    public float SFXVolume, MusicVolume;
    public bool useFullScreen;

    public int screenWidth = -1, screenHeight = -1, ResolutionIndex = -1;
}
