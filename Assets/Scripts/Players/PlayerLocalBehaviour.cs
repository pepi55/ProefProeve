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

	protected static Dictionary<int, bool> _playerUltActivations;
	protected Vector2 _playerDirection;

	private int playerSpeed;

	protected void Awake ()
	{
		_playerUltActivations = new Dictionary<int, bool>();
		_playerDirection = new Vector2();
	}

	protected virtual void Start ()
	{
		playerSpeed = 5;
		_playerUltActivations.Add(gameObject.GetInstanceID(), false);
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
	/// Implementation of <see cref="IPlayerBehaviour.IsDead()"/>.
	/// </summary>
	public void IsDead ()
	{
		if (PlayerHealth <= 0.0f)
		{
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// Handles player specific ability.
	/// Implementation of <see cref="IPlayerBehaviour.Ability1()"/>.
	/// </summary>
	public virtual void Ability1 ()
	{
	}

	/// <summary>
	/// Handles the Ult ability.
	/// Implementation of <see cref="IPlayerBehaviour.Ability2()"/>.
	/// </summary>
	public virtual void Ability2 ()
	{
		if (_playerUltActivations.Count > 0)
		{
			int id = gameObject.GetInstanceID();

			if (!_playerUltActivations.ContainsKey(id))
			{
				Debug.LogError("No current player key present.");
				return;
			}

			Debug.Log(_playerUltActivations[id]);
			_playerUltActivations[id] = true;

			foreach (KeyValuePair<int, bool> ultActive in _playerUltActivations)
			{
				Debug.Log("Key: " + ultActive.Key + " Value: " + ultActive.Value);
				/// FIXME: Not all values are reset back to false causing multiple ult activations.
				if (!ultActive.Value)
				{
					return;
				}
			}

			Debug.Log("Rip Jan");

			_playerUltActivations[id] = false;
			Debug.Log(_playerUltActivations[id]);
		}
	}
}
