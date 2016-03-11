//Author Jesse Stam
//Date 10-3-2016

using UnityEngine;
using System.Collections;

public class EnemyBasicShoot : EnemyBaseInterface
{
    System.DateTime LastShot;
    float Delay = 0.4f;

    public void DoAction(GameObject Entity)
    {
        if ((System.DateTime.Now - LastShot).TotalSeconds > Delay)
        {
            Delay = Random.Range(0.1f, 4f);
            LastShot = System.DateTime.Now;

            BaseProjectile p = BulletManager.GetEnemyBullet();

            p.transform.position = Entity.transform.position;
            p.Reset();
            p.rigidbody.velocity = Vector3.back * 3f;
        }
    }
}
