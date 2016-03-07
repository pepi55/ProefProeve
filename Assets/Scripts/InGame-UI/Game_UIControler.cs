using UnityEngine;
using System.Collections;

public class Game_UIControler : MonoBehaviour {

    [SerializeField]
    StatusBar PlayerHealth;
    [SerializeField]
    StatusBar SuperAttackChargeBar;

    protected float Player;
    protected void Start()
    {

    }

    public void Update()
    {
        PlayerHealth.Value = Player;
        SuperAttackChargeBar.Value = Mathf.PingPong(Time.time - 0.5f, 1f);
    }
}
