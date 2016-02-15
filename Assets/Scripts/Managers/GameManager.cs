using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameManager instance
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
    private GameManager _instance;

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
