using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        GetComponent<Renderer>().material.color = Color.blue;
    }
}
