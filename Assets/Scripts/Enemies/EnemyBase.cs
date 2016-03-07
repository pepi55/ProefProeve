//Author Jesse Stam
//26-2-2016
using UnityEngine;
using System.Collections;


public class EnemyBase : MonoBehaviour
{
	public bool IsAlive { get; private set; }

	public void OnTriggerEnter(Collider other)
	{
		IsAlive = false;

		GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Renderer>().material.color = Color.blue;

        GetComponent<BoxCollider>().enabled = false;
    }
}
