using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Singletons
{
	public static GameManager gameManager;
}

public static class Statistics
{
    #region Enemy Statistics
    public static float enemyHealth = 1;
    public static float enemyDamage = 1;
    #endregion

    #region Ally Stats
    public static float beeAttack = 1;
    public static float beeHeal = 1;
    public static float beeAttackSpeed = 1;
    #endregion
}
