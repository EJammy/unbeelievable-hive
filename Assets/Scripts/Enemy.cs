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

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        isAttacking = false;
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
            // Attack 
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
        } else
        {
            Debug.Log(other.tag);
        }
    }
    #endregion
}
