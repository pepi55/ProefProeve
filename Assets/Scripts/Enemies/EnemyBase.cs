//Author Jesse Stam
//26-2-2016

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class EnemyBase : MonoBehaviour
{
    System.DateTime StartLive;

    //private Renderer render;
    //public Renderer Render
    //{
    //    get
    //    {
    //        if (render == null)
    //            render = GetComponent<Renderer>();
    //        return render;
    //    }
    //}

    new private Rigidbody rigidbody;
    public Rigidbody Rigidbody { get { return rigidbody; } }
    private Color TmpColor;
    private bool removeActive;
    private bool isStunnedNow = false;
    private GameObject target = null;

    public bool IsAlive { get; private set; }
    public bool IsRemoved { get; private set; }

    //This needs a better name
    IEnemyBaseInterface Action;

    Vector3 orignalSpeed;

    private void Awake()
    {
        //render = GetComponent<Renderer>();
        //render.material.color = Color.white;

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;

        IsAlive = true;

        Action = new EnemyBasicShoot();

        Game_UIControler.onPause += onPause;
    }

    public void Reset()
    {
        IsAlive = true;
        IsRemoved = false;
        //Render.material.color = Color.white;
        gameObject.SetActive(true);
        GetComponent<BoxCollider>().enabled = true;
        Action = new EnemyEmptyBehaviour();
        StartLive = System.DateTime.Now;
        target = null;
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void Update()
    {
        if (!IsAlive)
        {
            //TmpColor = render.material.color;
            //TmpColor /= 3f * Time.deltaTime;
            //render.material.color = TmpColor;
        }
        else
        {
            if (target != null)
            {
                Action.DoAction(gameObject);
                transform.LookAt(target.transform);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Analilation Plane"))
        {
            Remove(0);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Remove(3);
        }
        else if (other.tag == "EnemySlow")
        {
            rigidbody.velocity /= 10f;
            // lookForPlayer();
            Action = new EnemyBasicShoot();
        }
    }

    void lookForPlayer()
    {
        int mask = 1 << LayerMask.NameToLayer("Player");
        RaycastHit[] hits = Physics.BoxCastAll(new Vector3(0, 0, 0), new Vector3(20, 20, 20), Vector3.back, transform.rotation, Mathf.Infinity,mask);
        GameObject closest = null;
        float shortest = Mathf.Infinity;
        foreach(RaycastHit h in hits)
        {
            if (Vector3.Distance(transform.position, h.collider.transform.position) < shortest)
            {
                closest = h.transform.gameObject;
                shortest = Vector3.Distance(transform.position, h.collider.transform.position);
            }
        }

        target = closest;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Analilation Plane"))
        {
            Remove(0);
        }
        else
        {
            Remove(3);
        }
    }

    public void Remove(float delay)
    {
        Debug.Log((System.DateTime.Now - StartLive).TotalSeconds);
        StartCoroutine(RemoveDelay(delay));
    }

    IEnumerator RemoveDelay(float delay)
    {
        if (!removeActive)
        {
            IsAlive = false;

            rigidbody.velocity = Vector3.zero;
            //render.material.color = Color.blue;
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

    public void onPause(bool b)
    {
        if (b)
        {
            orignalSpeed = rigidbody.velocity;
            rigidbody.velocity = Vector3.zero;

            enabled = false;
        }
        else
        {
            rigidbody.velocity = orignalSpeed;
            enabled = true;
        }
    }
}
