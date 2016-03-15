// Created by: Petar Dimitrov.
// Date: 25/02/2016

using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Extend this class to make a new Online player.
/// </summary>
public class PlayerOnlineBehaviour : NetworkBehaviour, IPlayerBehaviour
{
	public static float PlayerHealth { get { return PlayerStats.PlayerHealth; } private set { PlayerStats.PlayerHealth = value; } }

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
		if (!isLocalPlayer)
		{
			return;
		}

		gameObject.transform.Translate(dir * (Time.deltaTime * playerSpeed));
	}

	/// <summary>
	/// Implementation of <see cref="IPlayerBehaviour.IsDead()"/>.
	/// </summary>
	public void IsDead ()
	{
	}

	/// <summary>
	/// Implementation of <see cref="IPlayerBehaviour.Ability1()"/>.
	/// </summary>
	public void Ability1 ()
	{
		if (!isLocalPlayer)
		{
			return;
		}
	}

	/// <summary>
	/// Implementation of <see cref="IPlayerBehaviour.Ability2()"/>.
	/// </summary>
	public void Ability2 ()
	{
		if (!isLocalPlayer)
		{
			return;
		}
	}
}
