using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region BugType Enum
public enum BugType
{
    lvl0,
    lvl1,
    lvl2
}
#endregion

public class Bug : MonoBehaviour
{

#region Bug variables
    public BugType type { get; private set; }

    Room _workRoom;
    public Room WorkRoom { get { return _workRoom; }
        set {
            _workRoom.RemoveBug(this);
            _workRoom = value;
            if (value != null)
            {
                StartCoroutine(DelayMove());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
#endregion

#region Update Variables
    float moveTimer = 0;
    bool moving = false;
#endregion

#region Unity Functions
    void Start()
    {
        _workRoom = Singletons.hivemind;
        _workRoom.AddBug(this);
        transform.position = _workRoom.transform.position + (new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f)));
    }

    void Update()
    {
        if (moving) return;

        moveTimer += Time.deltaTime;
        if (moveTimer > 1)
        {
            moveTimer -= 1;
            if (Random.Range(0, 3) == 0)
            {
                StartCoroutine(MoveTo(transform.position, RandomTarget()));
            }
        }
    }
#endregion

#region Helper functions / Coroutines
    Vector2 RandomTarget()
    {
        Vector2 pos;
        do
        {
            pos = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f,10f));
        } while ( !_workRoom.GetComponent<Collider2D>().OverlapPoint(pos) );
        return pos;
    }

    IEnumerator MoveTo(Vector2 start, Vector2 end)
    {
        moving = true;
        const int total = 30;
        for (int i = 0; i < total; i++)
        {
            yield return new WaitForSeconds(0.05f);
            transform.position = Vector2.Lerp(start, end, ((float)i)/total);
        }
        moving = false;
    }

    IEnumerator DelayMove() {
        yield return new WaitForSeconds(0.1f);
        WorkRoom.AddBug(this);
        transform.position = RandomTarget();
    }
#endregion

}
