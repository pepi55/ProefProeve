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

    //int frame;
    //float time;
    //void Update()
    //{
    //    frame++;
    //    time += Time.deltaTime;

    //    if (time >= 1)
    //    {
    //        time = 0;
    //        Util.Debugger.Log("FPS", frame);
    //        frame = 0;
           
    //    }
    //}
}
