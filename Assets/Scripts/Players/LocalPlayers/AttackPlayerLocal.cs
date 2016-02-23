// Created by: Petar Dimitrov.
// Date: 23/02/2016

using UnityEngine;

public class AttackPlayerLocal : PlayerBehaviour
{
	public override void MainUpdate ()
	{
		playerDirection = Vector2.zero;

		if (Input.GetKey(KeyCode.D))
		{
			playerDirection += Vector2.right;
		}

		if (Input.GetKey(KeyCode.A))
		{
			playerDirection += Vector2.left;
		}

		if (Input.GetKey(KeyCode.W))
		{
			playerDirection += Vector2.up;
		}

		if (Input.GetKey(KeyCode.S))
		{
			playerDirection += Vector2.down;
		}

		if (playerDirection != Vector2.zero)
		{
			Move(playerDirection);
		}
	}
}
