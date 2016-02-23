// Created by: Petar Dimitrov.
// Date: 23/02/2016

using UnityEngine;

public class AttackPlayerLocal : PlayerBehaviour
{
	public override void MainUpdate ()
	{
		_playerDirection = Vector2.zero;

		if (Input.GetKey(KeyCode.D))
		{
			_playerDirection += Vector2.right;
		}

		if (Input.GetKey(KeyCode.A))
		{
			_playerDirection += Vector2.left;
		}

		if (Input.GetKey(KeyCode.W))
		{
			_playerDirection += Vector2.up;
		}

		if (Input.GetKey(KeyCode.S))
		{
			_playerDirection += Vector2.down;
		}

		if (_playerDirection != Vector2.zero)
		{
			Move(_playerDirection);
		}
	}
}
