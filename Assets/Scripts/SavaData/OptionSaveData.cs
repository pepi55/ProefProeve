using UnityEngine;
using System.Collections;

[System.Serializable]
public class OptionSaveData
{
    public float SFXVolume = 1, MusicVolume = 0.5f;
    public bool useFullScreen = false;
    public bool Vsync =false;

    public int screenWidth = -1, screenHeight = -1, ResolutionIndex = -1;
}
