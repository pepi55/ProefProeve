// Created by: Petar Dimitrov.
// Date: 22/02/2016

using Events;
using UnityEngine;

/// <summary>
/// Extend this class to make a new player.
/// </summary>
public class PlayerBehaviour : BaseBehaviour
{
	protected void Move (Vector2 dir)
	{
		gameObject.transform.Translate(dir * Time.deltaTime);
	}

	protected virtual void Attack ()
	{
		GlobalEvents.Invoke(new AttackEvent());
	}

	protected virtual void Deflect ()
	{
		GlobalEvents.Invoke(new DeflectEvent());
	}

	protected virtual void Ultimate ()
	{
		GlobalEvents.Invoke(new UltEvent());
	}
}
