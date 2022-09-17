using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Movement Variables
    public float speed;
    private Rigidbody2D EnemyRB;
    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector3.zero - transform.position;
        EnemyRB.velocity = direction.normalized * speed;
    }
    #endregion
}
