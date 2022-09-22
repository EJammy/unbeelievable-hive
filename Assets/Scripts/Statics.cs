using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Singletons
{
    public static GameManager gameManager;
    public static Hivemind hivemind;
}

public static class Statistics
{

    #region Player Resource
    static public float honey { get; set; }
    #endregion

    #region Enemy Statistics
    public static float enemyHealth = 1;
    public static float enemyDamage = 1;
    public static float enemySpeed = 1;
    #endregion

    #region Ally Stats
    public static float beeAttack = 1;
    public static float beeHeal = 1;
    public static float beeAttackSpeed = 1;
    #endregion

    #region Room Stats
    public static float roomMaxHp = 15;
    #endregion

    #region Upgrade Stats
    public static float upgradeAtkSpdPrice = 20;
    public static float upgradeAtkDmgPrice = 20;
    public static float upgradeWallHealthPrice = 20;
    #endregion
}
