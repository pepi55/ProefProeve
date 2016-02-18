using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ResolutionSelector : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Dropdown _dropdown = null;

    public UnityEngine.UI.Dropdown dropdown
    {
        get
        {
            return _dropdown;
        }
    }

    List<Resolution> resolutions;
    void Awake()
    {
        _dropdown.ClearOptions();
        resolutions = new List<Resolution>();

        Resolution[] temparr = Screen.resolutions;
        List<string> options = new List<string>();

        foreach(Resolution r in temparr)
        {
            if (r.height >= 600)
            {
                options.Add(r.width.ToString() + "x" + r.height.ToString());
                resolutions.Add(r);
            }
        }

        _dropdown.AddOptions(options);
    }

    public Resolution getCurrentResolution()
    {
        return resolutions[_dropdown.value];
    }
}
