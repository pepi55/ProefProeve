//Author Jesse Stam
//Created 15-2-2016
using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    static bool helpShow;

    [SerializeField]
    OptionsMenu options;

    [SerializeField]
    GameObject Main, Help;

    void Start()
    {
        if (helpShow)
        {
            Main.SetActive(true);
            Help.SetActive(false);
        }
        else
        {
            Main.SetActive(false);
            Help.SetActive(true);
        }
    }

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
        SceneControler.Load("Main");
    }

    public void OpenHelp()
    {
        Main.SetActive(false);
        Help.SetActive(true);
    }

    public void CloseHelp()
    {
        Main.SetActive(true);
        Help.SetActive(false);
    }

    void OpenMain()
    {
        options.CloseMenu();
        Main.SetActive(true);
        Help.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OpenMain();
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
