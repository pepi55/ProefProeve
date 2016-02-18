//Author Jesse Stam
//Created 15-2-2016
using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    OptionsMenu options;

	public void Options(bool open)
    {
        options.OpenMenu();
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {

    }

    void Update()
    {
        Util.Debugger.Log("FPS", 1000 * Time.deltaTime);
    }
}
