//Author Jesse Stam
//26-2-2016
using UnityEngine;
using System.Collections;


public class EnemyBase : MonoBehaviour
{
    private Renderer render;
    private Color TmpColor;
    bool RemoveEnum;


    private void Awake()
    {
        render = GetComponent<Renderer>();
        render.material.color = Color.red;
        IsAlive = true;
    }

	public bool IsAlive { get; private set; }

    public void Reset()
    {
        IsAlive = true;
        render.material.color = Color.red;
        gameObject.SetActive(true);
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
        GetComponent<Renderer>().material.color = Color.blue;

        GetComponent<BoxCollider>().enabled = false;
    }

    public void Remove(float delay)
    {

    }

    IEnumerator RemoveDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
