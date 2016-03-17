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

	new private Rigidbody rigidbody;
	public Rigidbody Rigidbody { get { return rigidbody; } }
	private Color TmpColor;
	bool removeActive;
    bool isStunnedNow = false;

	public bool IsAlive { get; private set; }
	public bool IsRemoved { get; private set; }

	//This needs a better name
	IEnemyBaseInterface Action;

	private void Awake()
	{
		render = GetComponent<Renderer>();
		render.material.color = Color.white;

		rigidbody = GetComponent<Rigidbody>();
		rigidbody.useGravity = false;

		IsAlive = true;

		Action = new EnemyBasicShoot();
	}	

	public void Reset()
	{
		IsAlive = true;
		IsRemoved = false;
		Render.material.color = Color.white;
		gameObject.SetActive(true);
		GetComponent<BoxCollider>().enabled = true;
		Action = new EnemyBasicShoot();
	}

    private void Update()
    {
        if (!IsAlive)
        {
            TmpColor = render.material.color;
            TmpColor /= 3f * Time.deltaTime;
            render.material.color = TmpColor;
        }
        else
        {
            Action.DoAction(gameObject);
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Analilation Plane"))
			Remove(0);
		else
			Remove(3);
	}

	public void Remove(float delay)
	{
		StartCoroutine(RemoveDelay(delay));
	}

	IEnumerator RemoveDelay(float delay)
	{
		if (!removeActive)
		{
			IsAlive = false;

			rigidbody.velocity = Vector3.zero;
			render.material.color = Color.blue;
			GetComponent<BoxCollider>().enabled = false;

			removeActive = true;
			yield return new WaitForSeconds(delay);
			removeActive = false;
			IsRemoved = true;
			gameObject.SetActive(false);
		}
	}

	public void isHit()
	{
		Remove(0.3f);
	}

    public void IsStunned(float duration = 5f)
    {
        StartCoroutine(IsStunnedEnumerator(duration));
    }

    IEnumerator IsStunnedEnumerator(float duration)
    {
        if (!isStunnedNow)
        {
            isStunnedNow = true;
            Vector3 StartingSpeed = rigidbody.velocity;
            rigidbody.velocity = Vector3.zero;

            float time = duration;

            while (time > 0)
            {
                time -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            rigidbody.velocity = StartingSpeed;
            isStunnedNow = false;
        }
        

    }
}
