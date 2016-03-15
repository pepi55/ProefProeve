//Author Jesse Stam
//Date 10-3-2016

using UnityEngine;

public class EnemyBasicShoot : IEnemyBaseInterface
{
	System.DateTime LastShot;
	float Delay = 0.4f;

	public void DoAction(GameObject entity)
	{
		if ((System.DateTime.Now - LastShot).TotalSeconds > Delay)
		{
			Delay = Random.Range(0.1f, 4f);
			LastShot = System.DateTime.Now;

			BaseProjectile p = BulletManager.GetEnemyBullet();

			p.transform.position = entity.transform.position;
			p.Reset();
			p.rigidbody.velocity = Vector3.back * (8f + Random.Range(0f,0.5f));
		}
	}
}
