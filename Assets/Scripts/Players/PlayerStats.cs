//Author Jesse Stam
//7-3-2016

public static class PlayerStats
{
	private static float _playerHealth = 100;
	public static float PlayerHealth
	{
		get { return _playerHealth; }
		set { _playerHealth = value; }
	}

	public static float SuperAttack { get; set; }
}
