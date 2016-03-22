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
    [SerializeField]
    UnityEngine.UI.Text ScoreIndicator; 
    [SerializeField]
    GameObject PauseMenu, InGameUI;

    //TMP need to find better place;
    float score = 0;
    //tells UI if it's paused;
    bool paused;

	private float Player;
	private void Start()
	{
        PauseMenu.SetActive(false);
	}

	private void Update()
	{
        PlayerHealth.Value = PlayerLocalBehaviour.PlayerHealth / 100f;
        SuperAttackChargeBar.Value = PlayerLocalBehaviour.UltChargeMeter / 10f;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (!paused)
        {
            score += Time.deltaTime / 10f;
            UpdateScoreIndicator();
        }
        
	}

    public void Pause()
    {
        if (onPause != null)
            onPause(true);

        paused = true;
        PauseMenu.SetActive(true);
        InGameUI.SetActive(false);
    }

    public void Continue()
    {
        if (onPause != null)
            onPause(false);
        paused = false;
        PauseMenu.SetActive(false);
        InGameUI.SetActive(true);
    }

    public void ExitToMain()
    {
        SceneControler.Load("MainMenu");
    }

    public void UpdateScoreIndicator()
    {
        string newText = Mathf.RoundToInt(score).ToString();

        for (int i = newText.Length; i < 3; i++)
        {
            newText = "0" + newText;
        }

        ScoreIndicator.text = "MegaMiles " +newText;
    }
}
