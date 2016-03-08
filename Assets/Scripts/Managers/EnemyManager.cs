// Created by: Jesse Stam.
//26-2-2016

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
	[SerializeField] private Vector3 spawnMin;
	[SerializeField] private Vector3 spawnMax;
	
    
    [SerializeField, Tooltip("A List of the enemies that can be spawned")]private GameObject[] SpawnAbleEnemies;
	[SerializeField, Tooltip("time in seconds")] private float SpawnDelay;

    private List<EnemyBase> enemyPool;

    private float spawnTimer;

	protected void Start ()
	{
        enemyPool = new List<EnemyBase>();
	}

    protected void Update()
    {
        if (spawnTimer > SpawnDelay)
        {
            if (SpawnAbleEnemies.Length > 0)
            {
                SpawnEnemies();
            }
            else
            {
                TestSpawn();
            }

            spawnTimer = 0;
        }

        spawnTimer += Time.deltaTime;
    }

	private void TestSpawn()
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

		r.velocity = new Vector3(0, 0, -5);
		r.useGravity = false;

		g.AddComponent<EnemyBase>();

		Destroy(g, 20f);
	}

	private void SpawnEnemies()
	{
		EnemyBase enemy = GetEnemy();
        enemy.Reset();
	}

	private EnemyBase GetEnemy()
	{
        EnemyBase SelectedEnemy = enemyPool.FirstOrDefault(x => x.IsAlive == true);
        if (SelectedEnemy)
            return SelectedEnemy;

        GameObject newEnemy = Instantiate(SpawnAbleEnemies[Random.Range(0, SpawnAbleEnemies.Length)]);

        SelectedEnemy = newEnemy.GetComponent<EnemyBase>();
        enemyPool.Add(SelectedEnemy);

        return SelectedEnemy;
	}

	private Vector3 RandomPos()
	{
		return new Vector3(Random.Range(spawnMin.x, spawnMax.x), Random.Range(spawnMin.y, spawnMax.y), Random.Range(spawnMin.z, spawnMax.z));
	}

	[ContextMenu("Center")]
	private void Center()
	{
		Vector3 startPos = transform.position;
		transform.position = Vector3.Lerp(spawnMax + transform.position, spawnMin + transform.position, 0.5f);
		Vector3 diff =transform.position - startPos;
		spawnMin -= diff;
		spawnMax -= diff;
	}

#if UNITY_EDITOR
    public Vector3 SpawnMin
    {
        get { return spawnMin; }
        set { spawnMin = value; }
    }

    public Vector3 SpawnMax
    {
        get { return spawnMax; }
        set { spawnMax = value; }
    }

    private Vector3 tmpMax;
	private Vector3 tmpMin;

    [SerializeField]
    private Color lineColor;

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
