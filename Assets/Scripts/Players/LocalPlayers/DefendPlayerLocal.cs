// Created by: Petar Dimitrov.
// Date: 23/02/2016

using UnityEngine;
using System.Collections;

public class DefendPlayerLocal : PlayerLocalBehaviour, IPlayerBehaviour
{
	[SerializeField] private GameObject playerShield;

	public float ShieldCooldown { get; private set; }
	public float StunCooldown { get; private set; }

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

		if (Input.GetKeyDown(KeyCode.H))
		{
			TakeDmg(10.0f);
		}
	}

	public override void TakeDmg (float val)
	{
		PlayerHealth -= ((val / 5) * 4);

		base.TakeDmg(val);
	}

	public override void Ability1 ()
	{
		if (ShieldCooldown <= 0.0f)
		{
			StartCoroutine(ActivateShield());
		}
	}

	private void Stun ()
	{
		if (StunCooldown <= 0.0f)
		{
			StartCoroutine(ActivateStun());
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

	private IEnumerator ActivateStun ()
	{
		StunCooldown = 2.0f;

		int mask = 1 << LayerMask.NameToLayer("Enemy");
		RaycastHit[] hits = Physics.BoxCastAll(transform.position, Vector3.one, Vector3.forward, Quaternion.identity, 3.0f, mask);

		if (hits.Length > 0)
		{
			foreach (RaycastHit hit in hits)
			{
				hit.collider.transform.gameObject.SendMessage("isStunned", SendMessageOptions.DontRequireReceiver);
			}
		}

		while (StunCooldown >= 0.0f)
		{
			StunCooldown-= Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}
}
