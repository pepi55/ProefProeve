using UnityEngine;
using System.Collections;

public class BaseBehaviour : MonoBehaviour
{

    //MainThreadDeltaTime;
    System.DateTime t;
    protected System.TimeSpan deltaTimeMain;

    //SecondaryThreadDeltaTime;
    System.DateTime t2;
    protected System.TimeSpan deltaTimeSecondary;

    private bool startedSecondThread;

    protected virtual void Start()
    {
        StartMainThreadUpdate();
    }

    protected void CalcDeltaTimeMain()
    {
        deltaTimeMain = (t - System.DateTime.Now);
        t = System.DateTime.Now;
    }

    protected void CalcDeltaTimeSecondary()
    {
        deltaTimeSecondary = (t2 - System.DateTime.Now);
        t2 = System.DateTime.Now;
    }

    protected void StartMainThreadUpdate()
    {
        ScriptManager.registerScriptMainThread(this);
    }

    protected void StartSecondThreadUpdate()
    {
        ScriptManager.registerScriptSecondaryThread(this);
        startedSecondThread = true;
    }

    protected void OnDestroy()
    {
        if (!Application.isPlaying)
            return;

        ScriptManager.unregisterScriptMainThread(this);
        if (startedSecondThread)
            ScriptManager.unregisterScriptSecondaryThread(this);
    }

    virtual protected void OnEnable()
    {
        StartMainThreadUpdate();
    }

    virtual protected void OnDisable()
    {
        ScriptManager.unregisterScriptMainThread(this);
        if (startedSecondThread)
            ScriptManager.unregisterScriptSecondaryThread(this);
    }

    /// <summary>
    /// runs in the main thread of unity
    /// should be used for allthings rendering
    /// </summary>
    public virtual void MainUpdate() { }

    /// <summary>
    /// runs in a self managed thread so out side the main thread of unity
    /// Can be used for things like pathfinding
    /// </summary>
    public virtual void SecondaryThreadUpdate() { }
}
