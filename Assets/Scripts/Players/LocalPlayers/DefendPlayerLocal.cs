// Created by: Petar Dimitrov.
// Date: 23/02/2016

using UnityEngine;

public class DefendPlayerLocal : PlayerLocalBehaviour, IPlayerBehaviour
{
	protected void Update ()
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
