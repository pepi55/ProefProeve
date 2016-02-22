// Created by: Petar Dimitrov.
// Date: 22/02/2016

using UnityEngine;

public class AttackPlayer : PlayerBehaviour
{
	private Vector2 dir;

	protected override void Start ()
	{
		base.Start();

		dir = new Vector2();
	}

	public override void MainUpdate ()
	{
		dir = Vector2.zero;

		if (Input.GetKey(KeyCode.RightArrow))
		{
			dir += Vector2.right;
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			dir += Vector2.left;
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			dir += Vector2.up;
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			dir += Vector2.down;
		}

		if (dir != Vector2.zero)
		{
			Move(dir);
		}
	}
}
