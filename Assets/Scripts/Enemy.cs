using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Movement Variables
    public float speed;
    private Rigidbody2D EnemyRB;
    #endregion

    #region Attack Variables
    private bool isAttacking;
    private GameObject target;
    #endregion

    #region Health and Damage Variables
    private float currHp;
    [Tooltip("How often enemies attack")]
    public float attackSpeed;
    private float currAttackTimer;
    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        isAttacking = false;
        currHp = Statistics.enemyHealth;
        currAttackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
        {
            Vector2 direction = Vector3.zero - transform.position;
            EnemyRB.velocity = direction.normalized * speed;
        } else if (target != null)
        {
            Attack();
        } else
        {
            isAttacking = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Room"))
        {
            isAttacking = true;
            target = other.gameObject;
            EnemyRB.velocity = Vector2.zero;
            currAttackTimer = 0;
        } else
        {
            // Debug.Log(other.tag);
        }
    }
    #endregion

    #region Damage Functions
    private void Attack()
    {
        if (currAttackTimer >= attackSpeed)
        {
            // target.transform.GetComponent<Room>().TakeDamage(Statistics.enemyDamage);
            currAttackTimer = 0;
        } else 
        {
            currAttackTimer += Time.deltaTime;
        }
    }
    public void TakeDamage(float damage)
    {
        currHp -= damage;
        if (currHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
}
