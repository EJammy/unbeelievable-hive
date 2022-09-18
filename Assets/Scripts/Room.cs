using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	#region Health System
	float hp;

	public void TakeDamage(float amt) {
		hp -= amt;
	}
	#endregion

	#region Bug Control
	// Use set to optimize
	Dictionary<BugType, List<Bug>> Bugs = new();

	int level = 0;

	/// <summary>
	/// Add bug to this room
	/// </summary>
	public void AddBug(Bug target)
	{
		Bugs[target.type].Add(target);
		UpdateLevel();
	}

	void IncreaseBug(BugType type)
	{
		var target = Singletons.hivemind.DecreaseBug(type);
		if (target == null) return;
		target.WorkRoom = this;
	}

	// Remove bug and send it to the hivemind
	Bug RemoveBug(Bug target)
	{
		// Performs linear search
		Bugs[target.type].Remove(target);
		if (Singletons.hivemind != this)
		{
			target.WorkRoom = Singletons.hivemind;
		}
		UpdateLevel();
		return target;
	}

	Bug DecreaseBug(BugType type)
	{
		// Can be optimized
		if (Bugs[type].Count > 0)
			return RemoveBug(Bugs[type][Bugs[type].Count - 1]);
		return null;
	}
	#endregion

	bool hover;

	virtual protected void Awake()
	{
		Bugs.Add(BugType.lvl0, new List<Bug>());
	}

    // Start is called before the first frame update
    virtual protected void Start()
    { }

    // Update is called once per frame
    virtual protected void Update()
    {
		if (hover)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0)) IncreaseBug(BugType.lvl0);
			if (Input.GetKeyDown(KeyCode.Mouse1)) DecreaseBug(BugType.lvl0);
		}
    }

	void OnMouseEnter()
	{
		hover = true;
	}

	void OnMouseExit()
	{
		hover = false;
	}

	void UpdateLevel()
	{
		level = 0;
		foreach (var item in Bugs)
		{
			level += (((int)item.Key) + 1) * item.Value.Count;
		}
		Debug.Log(gameObject.name + ": level " + level);
	}
}
