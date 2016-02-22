//Author Jesse Stam
//Created 12-2-2016

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (_instance)
                return _instance;

            _instance = FindObjectOfType<GameManager>();

            if (_instance)
                return _instance;

            GameObject g = new GameObject("GameManager");
            _instance = g.AddComponent<GameManager>();

            return _instance;
        }
    }
    protected static GameManager _instance;

    protected void Awake()
    {
        _instance = this;
    }

    protected void Start()
    {

    }

    protected void Update()
    {

    }
}
