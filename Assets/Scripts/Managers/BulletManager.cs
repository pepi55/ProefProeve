//Author Jesse Stam
//Date 10-3-2016

using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class BulletManager : MonoBehaviour
{
    private static BulletManager instance;

    private List<BaseProjectile> PlayerProjectileList;
    private List<BaseProjectile> EnemyProjectileList;

   [SerializeField] private BaseProjectile PlayerProjectile = null;
   [SerializeField] private BaseProjectile EnemyProjectile  = null;

    void Awake()
    {
        instance = this;

        PlayerProjectileList = new List<BaseProjectile>();
        EnemyProjectileList = new List<BaseProjectile>();
    }

    private static void checkInstance()
    {
        if(!instance)
        {
            GameObject g = new GameObject("Bullet Manager");
            BulletManager bm = g.AddComponent<BulletManager>();
        }
    }

    public static BaseProjectile GetPlayerBullet()
    {
        checkInstance();

        if(instance.PlayerProjectileList.Any(x => x.IsRemoved == true))
        {
           return instance.PlayerProjectileList.First(x => x.IsRemoved == true);
        }

        GameObject NewBulletGameObject = Instantiate(instance.PlayerProjectile.gameObject);
        BaseProjectile NewBullet = NewBulletGameObject.GetComponent<BaseProjectile>();

        instance.PlayerProjectileList.Add(NewBullet);

        return NewBullet;
        
    }

    public static BaseProjectile GetEnemyBullet()
    {
        checkInstance();

        if (instance.EnemyProjectileList.Any(x => x.IsRemoved == true))
        {
            return instance.EnemyProjectileList.First(x => x.IsRemoved == true);
        }

        GameObject NewBulletGameObject = Instantiate(instance.EnemyProjectile.gameObject);
        BaseProjectile NewBullet = NewBulletGameObject.GetComponent<BaseProjectile>();

        instance.EnemyProjectileList.Add(NewBullet);

        return NewBullet;
    }
}