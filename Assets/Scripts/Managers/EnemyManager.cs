// Created by: Jesse Stam.
//26-2-2016

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance;

	[SerializeField] private EnemyBase[] spawnableBosses;
	[SerializeField] private Vector3 spawnMin;
	[SerializeField] private Vector3 spawnMax;
	[SerializeField] private float spawnRate;

	[SerializeField, Tooltip("A List of the enemies that can be spawned")]
	private GameObject[] spawnableEnemies; // was hard to read as one long line
	[SerializeField, Tooltip("time in seconds")] private float SpawnDelay;

	private List<EnemyBase> enemyPool;

	private float timeSinceGameStart;
	private float spawnTimer;

	private bool bossActive;

	protected void Awake ()
	{
        instance = this;
        Game_UIControler.onPause += Game_UIControler_onPause;

		enemyPool = new List<EnemyBase>();

		bossActive = false;

		if (spawnableEnemies == null)
		{
			spawnableEnemies = new GameObject[0];
		}
	}

    private void Game_UIControler_onPause(bool b)
    {
        enabled = !b;
    }

    protected void Update()
	{
		// Enemies respawn at an exponential decay rate (spawn faster depending on how
		// long you have been playing).
		if (spawnTimer > 1.5f + (5.0f * Mathf.Exp(-timeSinceGameStart / spawnRate)))
		{
			if (spawnableBosses.Length > 0)
			{
				if (timeSinceGameStart % 30 == 0)
				{
					SpawnBoss();
				}
			}

			if (spawnableEnemies.Length > 0 && !bossActive)
			{
				SpawnEnemies();
			}
			else if (!bossActive)
			{
				TestSpawn();
			}

			spawnTimer = 0;
		}

		spawnTimer += Time.deltaTime;
		timeSinceGameStart += Time.deltaTime;
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
		enemy.Rigidbody.velocity = new Vector3(0, 0, -5);
		enemy.transform.localPosition = RandomPos();
	}

    public static void HitAllEnemies()
    {
        foreach(EnemyBase e in instance.enemyPool)
        {
            if (e.IsAlive)
            {
                e.isHit();
            }
        }
    }

	private EnemyBase SpawnBoss()
	{
		EnemyBase SelectedEnemy;

		GameObject newEnemy = Instantiate(spawnableEnemies[Random.Range(0, spawnableBosses.Length)]);
		newEnemy.transform.SetParent(transform, false);
		SelectedEnemy = newEnemy.GetComponent<EnemyBase>();
		return SelectedEnemy;
	}

	private EnemyBase GetEnemy()
	{
		EnemyBase SelectedEnemy;

		if (enemyPool.Count > 0 && enemyPool.Any(x => x.IsRemoved == true))
		{
			SelectedEnemy = enemyPool.First(x => x.IsRemoved == true);
			if (SelectedEnemy)
			{
				return SelectedEnemy;
			}
		}

		GameObject newEnemy = Instantiate(spawnableEnemies[Random.Range(0, spawnableEnemies.Length)]);
		newEnemy.transform.SetParent(transform, false);
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

	[SerializeField] private Color lineColor;

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
