// Created by: Jesse Stam.
// Date: 07/03/2016

using UnityEngine;

public class EnemyBase : MonoBehaviour
{
	public bool IsAlive { get; private set; }

	public void OnTriggerEnter(Collider other)
	{
		IsAlive = false;

		GetComponent<Rigidbody>().velocity = Vector3.zero;
		GetComponent<Renderer>().material.color = Color.blue;
	}
}
