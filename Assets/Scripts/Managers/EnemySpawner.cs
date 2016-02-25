using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Vector3 spawnMin;
    [SerializeField]
    Vector3 spawnMax;
    
    void Start()
    {

    }

    float t;
    void Update()
    {
            TestSpawn();
    }

    void TestSpawn()
    {
        GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Destroy(g.GetComponent<BoxCollider>());
        g.name = "Test";
        g.transform.SetParent(transform, false);

        g.transform.localPosition = RandomPos();

        Destroy(g, 3f);
        
    }

    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(spawnMin.x, spawnMax.x), Random.Range(spawnMin.y, spawnMax.y), Random.Range(spawnMin.z, spawnMax.z));
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

        Gizmos.color = Color.yellow;
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
