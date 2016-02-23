// Created by: Petar Dimitrov.
// Date: 22/02/2016

using UnityEngine;

public class AttackPlayerOnline : PlayerBehaviour
{
	public override void MainUpdate ()
	{
		_playerDirection = Vector2.zero;

		if (Input.GetKey(KeyCode.RightArrow))
		{
			_playerDirection += Vector2.right;
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			_playerDirection += Vector2.left;
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			_playerDirection += Vector2.up;
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			_playerDirection += Vector2.down;
		}

		if (_playerDirection != Vector2.zero)
		{
			Move(_playerDirection);
		}
	}
}
