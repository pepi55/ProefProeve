using UnityEngine;
using System.Collections;

public class BaseProjectile : MonoBehaviour
{
    public bool IsAlive { get; private set; }
    public bool IsRemoved { get; private set; }
    private bool removeActive;

    new SphereCollider collider;
    Rigidbody rigibody;
    void Start()
    {
        Reset();
        collider = GetComponent<SphereCollider>();
        rigibody = GetComponent<Rigidbody>();
    }

    public void Reset()
    {
        IsAlive = true;
        IsRemoved = false;
        gameObject.SetActive(true);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Remove(0.3f);
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

            yield return new WaitForSeconds(delay);
            removeActive = false;
            IsRemoved = true;
            gameObject.SetActive(false);
        }
    }
}
