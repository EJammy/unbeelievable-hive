using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	// Use set to optimize
	Dictionary<BugType, List<Bug>> Bugs = new();

	int level = 0;

	bool hover;

	// [SerializeField]
	// KeyCode key;

	void Awake()
	{
		Bugs.Add(BugType.lvl0, new List<Bug>());
	}

    // Start is called before the first frame update
    void Start()
    {
        if (Singletons.gameManager.Hivemind == this)
		{
			Bugs[BugType.lvl0].Add(new Bug());
			Bugs[BugType.lvl0].Add(new Bug());
			Bugs[BugType.lvl0].Add(new Bug());
			Bugs[BugType.lvl0].Add(new Bug());
			Bugs[BugType.lvl0].Add(new Bug());
			Bugs[BugType.lvl0].Add(new Bug());
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (hover)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0)) AddBug(BugType.lvl0);
			if (Input.GetKeyDown(KeyCode.Mouse1)) RemoveBug(BugType.lvl0);
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

	void AddBug(Bug target)
	{
		Bugs[target.type].Add(target);
		if (Singletons.gameManager.Hivemind != this)
		{
			Singletons.gameManager.Hivemind.RemoveBug(target);
		}
		UpdateLevel();
	}

	void AddBug(BugType type)
	{
		var target = Singletons.gameManager.Hivemind.RemoveBug(type);
		Bugs[target.type].Add(target);
		UpdateLevel();
	}

	Bug RemoveBug(Bug target)
	{
		// Performs linear search
		Bugs[target.type].Remove(target);
		if (Singletons.gameManager.Hivemind != this)
		{
			Singletons.gameManager.Hivemind.AddBug(target);
		}
		UpdateLevel();
		return target;
	}

	Bug RemoveBug(BugType type)
	{
		// Can be optimized
		return RemoveBug(Bugs[type][Bugs[type].Count - 1]);
	}

}
