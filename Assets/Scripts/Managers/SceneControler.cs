using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public static class SceneControler
{

    public static void Load(string SceneName)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }

    public static void LoadAddative(string SceneName)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
    }

    public static void UnloadScene(string SceneName)
    {
        Scene[] scenes = SceneManager.GetAllScenes();

        foreach (Scene s in scenes)
        {
            if(SceneName == s.name)
            {
                SceneManager.UnloadScene(s.name);
            }
        }
    }
}
