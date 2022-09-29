using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    #region Menu Variables
    public bool isOpen;
    public GameObject upgradeMenu;

    public TextMeshProUGUI textAtkDmg;
    public TextMeshProUGUI textAtkSpd;
    public TextMeshProUGUI textWallHp;
    #endregion

    #region Unity Functions
    private void Start()
    {
        Singletons.isUpgradeMenuOpen = false;
        upgradeMenu.SetActive(false);
    }
    private void Update()
    {
        if (Singletons.isUpgradeMenuOpen)
        {
            textAtkDmg.text = "$ " + Statistics.upgradeAtkDmgPrice;
            textAtkSpd.text = "$ " + Statistics.upgradeAtkSpdPrice;
            textWallHp.text = "$ " + Statistics.upgradeWallHealthPrice;
        }
    }
    #endregion

    #region Menu Functions
    public void HandleMenu()
    {
        upgradeMenu.SetActive(!Singletons.isUpgradeMenuOpen);
        Singletons.isUpgradeMenuOpen = !Singletons.isUpgradeMenuOpen;
    }
    #endregion

    #region Upgrade Functions
    public void UpgradeWallHealth()
    {
        if (Statistics.honey < Statistics.upgradeWallHealthPrice)
        {
            return;
        }
        Statistics.honey -= Statistics.upgradeWallHealthPrice;
        Statistics.upgradeWallHealthPrice = CalcNewPrice(Statistics.upgradeWallHealthPrice);
    }

    public void UpgradeBeeDamage()
    {
        if (Statistics.honey < Statistics.upgradeAtkDmgPrice)
        {
            return;
        }
        Statistics.honey -= Statistics.upgradeAtkDmgPrice;
        Statistics.beeAttack += 1;
        Debug.Log("Attack is now " + Statistics.beeAttack);
        Statistics.upgradeAtkDmgPrice = CalcNewPrice(Statistics.upgradeAtkDmgPrice);
    }

    int atkLevel = 0;
    public void UpgradeBeeAttackSpeed()
    {
        if (Statistics.honey < Statistics.upgradeAtkSpdPrice)
        {
            return;
        }
        Statistics.honey -= Statistics.upgradeAtkSpdPrice;
        atkLevel += 1;
        Statistics.beeAttackSpeed = 2f/(2 + atkLevel);
        Debug.Log("Attack speed " + Statistics.beeAttackSpeed);
        Statistics.upgradeAtkSpdPrice = CalcNewPrice(Statistics.upgradeAtkSpdPrice);
    }

    // Not implemented
    public void UpgradeHealSpeed()
    {
        Statistics.beeHeal += 1;
        Debug.Log("Bee Heal is now " + Statistics.beeHeal);
    }
    #endregion

    #region Price Functions
    private float CalcNewPrice(float oldPrice)
    {
        return oldPrice * 2;
        if (oldPrice < 100)
        {
            return oldPrice + 20;
        } else if (oldPrice < 500)
        {
            return oldPrice + 100;
        } else {
            return oldPrice + 500;
        }
    }
    #endregion
}
