//Author Jesse Stam
//23-2-2016

using UnityEngine;
using System.Collections;

public class Game_UIControler : MonoBehaviour {
    public static event BoolDelegate onPause;


	[SerializeField]
	StatusBar PlayerHealth;
	[SerializeField]
	StatusBar SuperAttackChargeBar;

    GameObject PauseMenu, InGAmeUI;

	private float Player;
	private void Start()
	{

	}

	private void Update()
	{
        PlayerHealth.Value = PlayerLocalBehaviour.PlayerHealth / 100f;
        SuperAttackChargeBar.Value = PlayerLocalBehaviour.UltChargeMeter / 10f;
        
	}

    public void ShowPause()
    {
        if (onPause != null)
            onPause(true);

        PauseMenu.SetActive(true);
        InGAmeUI.SetActive(false);
    }

    public void Continue()
    {
        if (onPause != null)
            onPause(false);

        PauseMenu.SetActive(false);
        InGAmeUI.SetActive(true);
    }

    public void ExitToMain()
    {
        SceneControler.Load("MainMenu");
    }
}
