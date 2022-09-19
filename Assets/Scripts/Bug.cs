
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BugType
{
	lvl0,
	lvl1,
	lvl2
}

public class Bug : MonoBehaviour
{
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

	void Start()
	{
		_workRoom = Singletons.hivemind;
		_workRoom.AddBug(this);
		transform.position = _workRoom.transform.position + (new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f)));
	}

	IEnumerator DelayMove() {
		yield return new WaitForSeconds(1);
		WorkRoom.AddBug(this);
		transform.position = WorkRoom.transform.position + (new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f)));
	}

}
