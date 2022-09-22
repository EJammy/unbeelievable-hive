using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDefender : MonoBehaviour
{
    #region Attacking variables
    public GameObject target;
    private float currAttackTimer;
    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        currAttackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && currAttackTimer >= Statistics.beeAttackSpeed)
        {
            Attack();
        } else
        {
            currAttackTimer += Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (target == null && collision.CompareTag("Enemy"))
        {
            target = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            target = null;
        }
    }
    #endregion

    #region Attack Functions
    private void Attack()
    {
        Debug.Log("Attacking");
        target.GetComponent<Enemy>().TakeDamage(Statistics.beeAttack);
        currAttackTimer = 0;
    }
    #endregion
}
