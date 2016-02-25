// Created by: Petar Dimitrov.
// Date: 23/02/2016

using UnityEngine;

/// <summary>
/// Extend this class to make a new Local player.
/// </summary>
public class PlayerLocalBehaviour : MonoBehaviour, IPlayerBehaviour
{
	public static int PlayerHealth { get; private set; }

	protected Vector2 _playerDirection;
	private int playerSpeed;

	protected void Start ()
	{
		_playerDirection = new Vector2();
		playerSpeed = 5;
	}

	/// <summary>
	/// Implementation of <see cref="IPlayerBehaviour.Move(Vector2)"/>.
	/// </summary>
	/// <param name="dir">The direction to move the player in.</param>
	public void Move (Vector2 dir)
	{
		gameObject.transform.Translate(dir * (Time.deltaTime * playerSpeed));

		/*
		Vector2 tempPos = gameObject.transform.position;

		if (gameObject.transform.position.x <= 0)
		{
			tempPos.x = 0;
		}

		if (gameObject.transform.position.x >= Screen.width)
		{
			tempPos.x = Screen.width;
		}

		if (gameObject.transform.position.y <= 0)
		{
			tempPos.y = 0;
		}

		if (gameObject.transform.position.y >= Screen.height)
		{
			tempPos.y = Screen.height;
		}

		gameObject.transform.position = tempPos;
		*/
	}

	/// <summary>
	/// Implementation of <see cref="IPlayerBehaviour.Ability1()"/>.
	/// </summary>
	public void Ability1 ()
	{
	}

	/// <summary>
	/// Implementation of <see cref="IPlayerBehaviour.Ability2()"/>.
	/// </summary>
	public void Ability2 ()
	{
	}
}
