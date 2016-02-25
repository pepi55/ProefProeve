using UnityEngine;
using System.Collections;

public class Game_UIControler : MonoBehaviour {

    [SerializeField]
    StatusBar PlayerHealth;
    [SerializeField]
    StatusBar SuperAttackChargeBar;
    protected void Start()
    {

    }

    public void Update()
    {
        PlayerHealth.Value = Mathf.PingPong(Time.time, 1f);
        SuperAttackChargeBar.Value = Mathf.PingPong(Time.time - 0.5f, 1f);
    }
}
