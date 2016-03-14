// Created by: Petar Dimitrov.
// Date: 23/02/2016

using UnityEngine;
using System.Collections;

public class DefendPlayerLocal : PlayerLocalBehaviour, IPlayerBehaviour
{
	[SerializeField] private GameObject playerShield;

	public float ShieldCooldown { get; private set; }

	protected override void Start ()
	{
		base.Start();

		ShieldCooldown = 0.0f;
		playerShield.SetActive(false);
	}

	protected void Update ()
	{
		_playerDirection = Vector2.zero;

		if (Input.GetKeyDown(KeyCode.RightControl))
		{
			Ability1();
		}

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			Ability2();
		}

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

	public override void Ability1()
	{
		if (ShieldCooldown <= 0.0f)
		{
			StartCoroutine(ActivateShield());
		}
	}

	private IEnumerator ActivateShield ()
	{
		ShieldCooldown = 1.5f;
		playerShield.SetActive(true);

		yield return new WaitForSeconds(1.0f);

		playerShield.SetActive(false);

		while (ShieldCooldown >= 0.0f)
		{
			ShieldCooldown -= Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}
}
