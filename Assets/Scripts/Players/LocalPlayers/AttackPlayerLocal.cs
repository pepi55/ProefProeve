// Created by: Petar Dimitrov.
// Date: 23/02/2016

using UnityEngine;

/// <summary>
/// Attack player for local play.
/// </summary>
public class AttackPlayerLocal : PlayerLocalBehaviour
{
	protected void Update ()
	{
		_playerDirection = Vector2.zero;

		if (Input.GetKeyDown(KeyCode.F))
		{
			Ability1();
		}

		if (Input.GetKeyDown(KeyCode.RightShift))
		{
			Ability2();
		}

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

	public override void Ability1()
	{
		int mask = 1 << LayerMask.NameToLayer("Enemy");
		RaycastHit[] hits = Physics.BoxCastAll(transform.position, Vector3.one, Vector3.forward, Quaternion.identity, 3.0f, mask);

		if (hits.Length > 0)
		{
			foreach (RaycastHit hit in hits)
			{
				hit.collider.transform.gameObject.SendMessage("isHit", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
