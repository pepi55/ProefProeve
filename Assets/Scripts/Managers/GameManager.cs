//Author Jesse Stam
//Created 12-2-2016

using UnityEngine;

public class GameManager : MonoBehaviour
{
	protected static GameManager _instance;
	public static GameManager Instance
	{
		get
		{
			if (_instance)
			{
				return _instance;
			}

			_instance = FindObjectOfType<GameManager>();

			if (_instance)
			{
				return _instance;
			}

			GameObject gameManager = new GameObject("GameManager");
			_instance = gameManager.AddComponent<GameManager>();

			return _instance;
		}

		private set
		{
			_instance = value;
		}
	}

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
