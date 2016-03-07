using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    //public for a editor script
    public Vector3 spawnMin;   
    public Vector3 spawnMax;

    [SerializeField]
    GameObject Enemy;

    [SerializeField, Tooltip("time in seconds")]
    float SpawnDelay = 0.05f;

#if UNITY_EDITOR
    [SerializeField]
    Color lineColor;
#endif

    void Start()
    {

    }

    float t;
    void Update()
    {
        if (t > SpawnDelay)
        {
            TestSpawn();
            t = 0;
        }

        t += Time.deltaTime;
    }

    void TestSpawn()
    {
        GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Destroy(g.GetComponent<BoxCollider>());
        g.name = "Test";
        PhysicMaterial pm = new PhysicMaterial("BOUNCE");
        pm.bounciness = 0.8f;
        g.GetComponent<BoxCollider>().material = pm;
        g.transform.SetParent(transform, false);
        g.transform.localPosition = RandomPos();

        Rigidbody r = g.AddComponent<Rigidbody>();

        r.velocity = new Vector3(0, 0, -2);
        r.useGravity = false;

        g.AddComponent<EnemyBase>();


        Destroy(g, 20f);

    }

    Vector3 RandomPos()
    {

        return new Vector3(Random.Range(spawnMin.x, spawnMax.x), Random.Range(spawnMin.y, spawnMax.y), Random.Range(spawnMin.z, spawnMax.z));
    }

    [ContextMenu("Center")]
    void Center()
    {
        Vector3 startPos = transform.position;
        transform.position = Vector3.Lerp(spawnMax + transform.position, spawnMin + transform.position, 0.5f);
        Vector3 diff =transform.position - startPos;
        spawnMin -= diff;
        spawnMax -= diff;
    }

#if UNITY_EDITOR
    Vector3 tmpMax;
    Vector3 tmpMin;
    public void OnDrawGizmosSelected()
    {
        tmpMax = transform.position + spawnMax;
        tmpMin = transform.position + spawnMin;
        Gizmos.color = Color.green;
        Gizmos.DrawCube(tmpMin, Vector3.one * 0.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawCube(tmpMax, Vector3.one * 0.5f);
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = lineColor;
        Gizmos.DrawLine(tmpMin, new Vector3(tmpMin.x, tmpMin.y, tmpMax.z));
        Gizmos.DrawLine(tmpMin, new Vector3(tmpMin.x, tmpMax.y, tmpMin.z));
        Gizmos.DrawLine(tmpMin, new Vector3(tmpMax.x, tmpMin.y, tmpMin.z));

        Gizmos.DrawLine(tmpMax, new Vector3(tmpMax.x, tmpMax.y, tmpMin.z));
        Gizmos.DrawLine(tmpMax, new Vector3(tmpMax.x, tmpMin.y, tmpMax.z));
        Gizmos.DrawLine(tmpMax, new Vector3(tmpMin.x, tmpMax.y, tmpMax.z));

        Gizmos.DrawLine(new Vector3(tmpMax.x, tmpMin.y, tmpMax.z), new Vector3(tmpMax.x, tmpMin.y, tmpMin.z));
        Gizmos.DrawLine(new Vector3(tmpMax.x, tmpMin.y, tmpMax.z), new Vector3(tmpMin.x, tmpMin.y, tmpMax.z));

        Gizmos.DrawLine(new Vector3(tmpMin.x, tmpMax.y, tmpMin.z), new Vector3(tmpMin.x, tmpMax.y, tmpMax.z));
        Gizmos.DrawLine(new Vector3(tmpMin.x, tmpMax.y, tmpMin.z), new Vector3(tmpMax.x, tmpMax.y, tmpMin.z));

        Gizmos.DrawLine(new Vector3(tmpMin.x, tmpMin.y, tmpMax.z), new Vector3(tmpMin.x, tmpMax.y, tmpMax.z));
        Gizmos.DrawLine(new Vector3(tmpMax.x, tmpMax.y, tmpMin.z), new Vector3(tmpMax.x, tmpMin.y, tmpMin.z));
    }


#endif

}
