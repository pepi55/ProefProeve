// Created by: Petar Dimitrov.
// Date: 23/02/2016

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Extend this class to make a new Local player.
/// </summary>
public class PlayerLocalBehaviour : MonoBehaviour, IPlayerBehaviour
{
	public static float PlayerHealth { get { return PlayerStats.PlayerHealth; } private set { PlayerStats.PlayerHealth = value; } }

	protected Vector2 _playerDirection;
	protected static Dictionary<int, bool> playerUltActivations;

	private int playerSpeed;

	protected virtual void Start ()
	{
		_playerDirection = new Vector2();

		playerUltActivations = new Dictionary<int, bool>();
		playerUltActivations.Add(gameObject.GetInstanceID(), false);

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
		if (playerUltActivations.Count > 0)
		{
			int id = gameObject.GetInstanceID();

			if (!playerUltActivations.ContainsKey(id))
			{
				Debug.LogError("No current player key present.");
				return;
			}

			playerUltActivations[id] = true;

			foreach (KeyValuePair<int, bool> ultActive in playerUltActivations)
			{
				Debug.Log("Key: " + ultActive.Key + " Value: " + ultActive.Value);
				Debug.Log(playerUltActivations.Count);
				if (ultActive.Value == false)
				{
					return;
				}
			}

			Debug.Log("Rip Jan");

			playerUltActivations[id] = false;
		}
	}
}
