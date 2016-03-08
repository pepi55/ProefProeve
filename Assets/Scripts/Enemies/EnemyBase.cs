//Author Jesse Stam
//26-2-2016
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class EnemyBase : MonoBehaviour
{
    private Renderer render;
    public Renderer Render
    {
        get
        {
            if (render == null)
                render = GetComponent<Renderer>();
            return render;
        }
    }

    private Rigidbody rigibody;
    public Rigidbody Rigibody { get { return rigibody; } }
    private Color TmpColor;
    bool RemveActive;

    public bool IsAlive { get; private set; }
    public bool IsRemoved { get; private set; }

    private void Awake()
    {
        render = GetComponent<Renderer>();
        render.material.color = Color.white;

        rigibody = GetComponent<Rigidbody>();
        rigibody.useGravity = false;

        IsAlive = true;
    }	

    public void Reset()
    {
        IsAlive = true;
        IsRemoved = false;
        Render.material.color = Color.white;
        gameObject.SetActive(true);
        GetComponent<BoxCollider>().enabled = true;
    }

    private void Update()
    {
        if(!IsAlive)
        {
            TmpColor = render.material.color;
            TmpColor /= 3f * Time.deltaTime;
            render.material.color = TmpColor;
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		IsAlive = false;

		GetComponent<Rigidbody>().velocity = Vector3.zero;
        render.material.color = Color.blue;

        GetComponent<BoxCollider>().enabled = false;

        Remove(3);
    }

    public void Remove(float delay)
    {
        StartCoroutine(RemoveDelay(delay));
    }

    IEnumerator RemoveDelay(float delay)
    {
        if (!RemveActive)
        {
            RemveActive = true;
            yield return new WaitForSeconds(delay);
            RemveActive = false;
            IsRemoved = true;
            gameObject.SetActive(false);
        }
    }
}
