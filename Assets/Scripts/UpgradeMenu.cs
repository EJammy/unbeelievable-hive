using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    #region Menu Variables
    private bool isOpen;
    public GameObject upgradeMenu;
    #endregion

    #region Unity Functions
    private void Start()
    {
        isOpen = false;
        upgradeMenu.SetActive(false);
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
        
    }

    public void UpgradeBeeDamage()
    {
        Statistics.beeAttack += 1;
        Debug.Log("Attack is now " + Statistics.beeAttack);
    }

    public void UpgradeBeeAttackSpeed()
    {
        Statistics.beeAttackSpeed -= 0.1f;
        Debug.Log("Attack speed " + Statistics.beeAttackSpeed);
    }

    public void UpgradeHealSpeed()
    {
        Statistics.beeHeal += 1;
        Debug.Log("Bee Heal is now " + Statistics.beeHeal);
    }
    #endregion
}
