// Created by: Petar Dimitrov.
// Date: 22/02/2016

using Events;
using UnityEngine;

/// <summary>
/// Extend this class to make a new player.
/// </summary>
public class PlayerBehaviour : MonoBehaviour
{
	protected Vector2 _playerDirection;
	private int _playerSpeed;

	protected void Start ()
    { 
		_playerSpeed = 5;
		_playerDirection = new Vector2();
	}

	protected void Move (Vector2 dir)
	{
		//if (isLocalPlayer)
		//{
		//	return;
		//}

		gameObject.transform.Translate(dir * (Time.deltaTime * _playerSpeed));
	}

	protected virtual void Attack ()
	{
		//if (!isLocalPlayer)
		//{
		//	return;
		//}

		GlobalEvents.Invoke(new AttackEvent());
	}

	protected virtual void Deflect ()
	{
		//if (!isLocalPlayer)
		//{
		//	return;
		//}

		GlobalEvents.Invoke(new DeflectEvent());
	}

	protected virtual void Ultimate ()
	{
		////if (!isLocalPlayer)
		////{
		////	return;
		////}

		GlobalEvents.Invoke(new UltEvent());
	}
}