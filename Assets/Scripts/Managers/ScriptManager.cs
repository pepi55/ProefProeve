using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ScriptManager : MonoBehaviour
{
    [SerializeField]
    protected List<BaseBehaviour> MainThreadScripts;

    [SerializeField]
    protected List<BaseBehaviour> SecondThreadScripts;
    private Thread secondaryThread;



    public static ScriptManager instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            if (!isPlaying)
                return null;

            if (!_instance)
                _instance = FindObjectOfType<ScriptManager>();

            if (!_instance)
            {
                GameObject g = new GameObject("Script Manager");
                _instance = g.AddComponent<ScriptManager>();
            }

            return _instance;
        }
    }
    private static ScriptManager _instance;

    private volatile bool _gamePaused = false;
    public static bool gamePaused
    {
        get
        {
            return instance._gamePaused;
        }

        set
        {
            instance._gamePaused = value;
        }
    }

    private volatile static bool isPlaying = true;
    public static System.TimeSpan PausedTime;

    #region Static Functions
    /// <summary>
    /// register a script to run it's main update loop code
    /// </summary>
    /// <param name="b"></param>
    public static void registerScriptMainThread(BaseBehaviour b)
    {
        if (instance == null && !isPlaying)
            return;

        if (!instance.MainThreadScripts.Contains(b))
            instance.MainThreadScripts.Add(b);
    }

    /// <summary>
    /// remove a script from running it's main update loop code
    /// </summary>
    /// <param name="b"></param>
    public static void unregisterScriptMainThread(BaseBehaviour b)
    {
        if (instance == null && !isPlaying)
            return;

        if (instance.MainThreadScripts.Contains(b))
            instance.MainThreadScripts.Remove(b);
    }

    /// <summary>
    /// add a script from running it's secondary thread loop code
    /// </summary>
    /// <param name="b"></param>
    public static void registerScriptSecondaryThread(BaseBehaviour b)
    {
        if (instance == null && !isPlaying)
            return;

        if (!instance.SecondThreadScripts.Contains(b))
            instance.SecondThreadScripts.Add(b);
    }

    public static void unregisterScriptSecondaryThread(BaseBehaviour b)
    {
        if (instance == null && !isPlaying)
            return;

        if (instance.SecondThreadScripts.Contains(b))
            instance.SecondThreadScripts.Remove(b);
    }
    #endregion

    void Awake()
    {
        if (_instance)
            Destroy(this);

        MainThreadScripts = new List<BaseBehaviour>();
        SecondThreadScripts = new List<BaseBehaviour>();
        PausedTime = new System.TimeSpan();

        DontDestroyOnLoad(this);
        _instance = this;

        secondaryThread = new Thread(SecondaryThreadUpdate);
        secondaryThread.Start();

        isPlaying = true;
    }

    public void OnDestroy()
    {
        isPlaying = false;
        //secondaryThread.Abort();
        secondaryThread = null;

        _instance = null;
    }

    int i;
    int l;
    /// <summary>
    /// Main Thread Update
    /// </summary>
    void Update()
    {
        if (!gamePaused)
        {
            l = MainThreadScripts.Count;
            for (i = 0; i < l; i++)
            {
                if (MainThreadScripts[i].enabled)
                    MainThreadScripts[i].MainUpdate();
            }
        }
        else
        {
            PausedTime.Add(new System.TimeSpan(0, 0, 0, 0, Mathf.FloorToInt(Time.deltaTime * 1000)));
        }
        //if (secondaryThread.ThreadState != ThreadState.Running )
        //    secondaryThread.Start();
    }

    int j;
    int k;
    /// <summary>
    /// Second thread opperation. Used for heavy scripts
    /// </summary>
    void SecondaryThreadUpdate()
    {
        while (isPlaying)
        {
            if (!gamePaused)
            {
                try
                {
                    k = SecondThreadScripts.Count;
                    for (j = 0; j < k; j++)
                    {
                        //if (SecondThreadScripts[j].enabled)
                            SecondThreadScripts[j].SecondaryThreadUpdate();
                    }
                }
                catch (System.Exception e)
                {
                    Debug.LogException(e);
                }

                Thread.Sleep(1);
            }
            else
            {
                Thread.Sleep(10);
            }
        }
    }
}
