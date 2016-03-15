// Created by: Petar Dimitrov.
// Date: 22/02/2016

using UnityEngine;

/// <summary>
/// Implement this interface to make a new player.
/// </summary>
public interface IPlayerBehaviour
{
	/// <summary>
	/// Handles movement for the player.
	/// </summary>
	/// <param name="dir">The direction to move the player in.</param>
	void Move(Vector2 dir);

	/// <summary>
	/// Checks if player is dead.
	/// </summary>
	void IsDead();

	/// <summary>
	/// The first player ability.
	/// </summary>
	void Ability1();

	/// <summary>
	/// The second player ability.
	/// </summary>
	void Ability2();
}
