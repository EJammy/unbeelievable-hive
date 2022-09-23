using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Movement Variables
    private float speed;
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

    #region Sprite Variables
    private SpriteRenderer sprite;
    private CircleCollider2D circleCollider;
    private Animator anim;
    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        isAttacking = false;
        currHp = Statistics.enemyHealth;
        currAttackTimer = 0;
        speed = Statistics.enemySpeed;
        sprite = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        if (this.transform.position.x > 0)
        {
            sprite.flipX = true;
            circleCollider.offset = new Vector2(-2, 0);
        } else
        {
            circleCollider.offset = new Vector2(2, 0);
        }
        anim = GetComponent<Animator>();
        anim.SetBool("isAttacking", false);
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
            if (currAttackTimer >= attackSpeed)
            {
                StartCoroutine(Attack());
            }
            else if (!anim.GetBool("isAttacking"))
            {
                currAttackTimer += Time.deltaTime;
            }
        } else
        {
            isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
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
    IEnumerator Attack()
    {
        anim.SetBool("isAttacking", true);
        currAttackTimer = 0;
        yield return new WaitForSeconds(1);
        target.transform.GetComponent<Room>().TakeDamage(Statistics.enemyDamage);
        Vector2 direction = Vector3.zero - transform.position;
        EnemyRB.velocity = direction.normalized * -0.001f;
        anim.SetBool("isAttacking", false);
        yield return null;
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
