// Created by: Petar Dimitrov.
// Date: 23/02/2016

using UnityEngine;

public class DefendPlayerLocal : PlayerBehaviour
{
	public override void MainUpdate ()
	{
		playerDirection = Vector2.zero;

		if (Input.GetKey(KeyCode.RightArrow))
		{
			playerDirection += Vector2.right;
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			playerDirection += Vector2.left;
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			playerDirection += Vector2.up;
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			playerDirection += Vector2.down;
		}

		if (playerDirection != Vector2.zero)
		{
			Move(playerDirection);
		}
	}
}
