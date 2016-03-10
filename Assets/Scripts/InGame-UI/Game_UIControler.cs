//Author Jesse Stam
//23-2-2016

using UnityEngine;
using System.Collections;

public class Game_UIControler : MonoBehaviour {

	[SerializeField]
	StatusBar PlayerHealth;
	[SerializeField]
	StatusBar SuperAttackChargeBar;

	private float Player;
	private void Start()
	{

	}

	private void Update()
	{
		PlayerHealth.Value = PlayerStats.PlayerHealth/100f;
		SuperAttackChargeBar.Value = Mathf.PingPong(Time.time - 0.5f, 1f);
	}
}
