﻿// Created by: Jesse Stam.
// Date: 17/03/2016

using UnityEngine;
using System.Collections;

using Events;

public class BaseProjectile : MonoBehaviour
{
	public bool IsAlive { get; private set; }
	public bool IsRemoved { get; private set; }
	private bool removeActive;

	[SerializeField] new SphereCollider collider;
	[SerializeField] new public Rigidbody rigidbody { get; private set; }

    Vector3 orignalSpeed;

	void Awake()
	{

		collider = GetComponent<SphereCollider>();
		rigidbody = GetComponent<Rigidbody>();

		rigidbody.useGravity = false;

		Reset();

        Game_UIControler.onPause += onPause;
	}

	public void Reset()
	{
		IsAlive = true;
		IsRemoved = false;
		collider.enabled = true;
		gameObject.SetActive(true);
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
            collision.collider.SendMessage("TakeDmg", 2f);
		}

		Remove(0.3f);
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Analilation Plane"))
		{
			Remove(0);
		}

		if (other.gameObject.layer == LayerMask.NameToLayer("PlayerShield"))
		{
			GlobalEvents.Invoke(new AbsorbedEvent());
			Remove(0);
		}
	}

	public void Remove(float delay)
	{
		StartCoroutine(RemoveDelay(delay));
	}

	IEnumerator RemoveDelay(float delay)
	{
		if (!removeActive)
		{
			removeActive = true;
			collider.enabled = false;
			rigidbody.velocity = Vector3.zero;

			yield return new WaitForSeconds(delay);
			removeActive = false;
			IsRemoved = true;
			gameObject.SetActive(false);
		}
	}

    public void onPause(bool b)
    {
        if (b)
        {
            orignalSpeed = rigidbody.velocity;
            rigidbody.velocity = Vector3.zero;
        }
        else
        {
            rigidbody.velocity = orignalSpeed;
        }
    }
}
