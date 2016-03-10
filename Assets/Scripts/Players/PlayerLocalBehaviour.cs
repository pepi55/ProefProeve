// Created by: Petar Dimitrov.
// Date: 23/02/2016

using UnityEngine;

/// <summary>
/// Extend this class to make a new Local player.
/// </summary>
public class PlayerLocalBehaviour : MonoBehaviour, IPlayerBehaviour
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
	public virtual void Move (Vector2 dir)
	{
		gameObject.transform.Translate(dir * (Time.deltaTime * playerSpeed));
	}

	/// <summary>
	/// Implementation of <see cref="IPlayerBehaviour.Ability1()"/>.
	/// </summary>
	public virtual void Ability1 ()
	{
	}

	/// <summary>
	/// Implementation of <see cref="IPlayerBehaviour.Ability2()"/>.
	/// </summary>
	public virtual void Ability2 ()
	{
	}
}
