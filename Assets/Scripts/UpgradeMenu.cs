using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    #region Menu Variables
    private bool isOpen;
    public GameObject upgradeMenu;

    public TextMeshProUGUI textAtkDmg;
    public TextMeshProUGUI textAtkSpd;
    public TextMeshProUGUI textWallHp;
    #endregion

    #region Unity Functions
    private void Start()
    {
        isOpen = false;
        upgradeMenu.SetActive(false);
    }
    private void Update()
    {
        if (isOpen)
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
        upgradeMenu.SetActive(!isOpen);
        isOpen = !isOpen;
    }
    #endregion

    #region Upgrade Functions
    public void UpgradeWallHealth()
    {
        Statistics.upgradeWallHealthPrice = CalcNewPrice(Statistics.upgradeWallHealthPrice);
    }

    public void UpgradeBeeDamage()
    {
        Statistics.beeAttack += 1;
        Debug.Log("Attack is now " + Statistics.beeAttack);
        Statistics.upgradeAtkDmgPrice = CalcNewPrice(Statistics.upgradeAtkDmgPrice);
    }

    public void UpgradeBeeAttackSpeed()
    {
        Statistics.beeAttackSpeed -= 0.1f;
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
