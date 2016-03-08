//Author Jesse Stam
//7-3-2016

using UnityEngine;
using System.Collections;

public class PlayerStats {

    private static float _playerHealth = 100;
    public static float playerHealth
    {
        get { return _playerHealth; }
        set { _playerHealth = value; }
    }

    private static float _superAttack;
    public static float superAttack
    {
        get { return _superAttack; }
        set { _superAttack = value; }
    }
}
