
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
			_workRoom = value;
			StartCoroutine(DelayMove());
		}
	}

	IEnumerator DelayMove() {
		yield return new WaitForSeconds(1);
		WorkRoom.AddBug(this);
	}

}
