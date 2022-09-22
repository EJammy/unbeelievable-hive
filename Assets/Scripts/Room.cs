using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    #region Health System
    float hp = 15;
    public Slider hpSlider;
    public Slider progressSlider;

    public void TakeDamage(float amt) {
        hp -= amt;
        hpSlider.value = Mathf.Max(hp / Statistics.roomMaxHp, 0);
        if (hp < 0)
        {
            DestroyRoom();
        }
    }

    virtual protected void DestroyRoom()
    {
        foreach (var item in Bugs)
        {
            foreach (var bug in item.Value)
            {
                bug.WorkRoom = Singletons.hivemind;
            }
        }
        Destroy(gameObject);
    }
    #endregion

    #region Bug Control
    // Use set to optimize
    Dictionary<BugType, List<Bug>> Bugs = new();

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
        var target = Singletons.hivemind.LastBug(type);
        if (target == null) return;
        target.WorkRoom = this;
    }

    // Remove bug
    public void RemoveBug(Bug target)
    {
        // Performs linear search
        Bugs[target.type].Remove(target);
        UpdateLevel();
    }

    public Bug LastBug(BugType type)
    {
        if (Bugs[type].Count > 0)
            return Bugs[type][Bugs[type].Count - 1];
        return null;
    }

    void DecreaseBug(BugType type)
    {
        // Can be optimized
        if (LastBug(type) != null)
            LastBug(type).WorkRoom = Singletons.hivemind;
    }

    public int GetBugAmount()
    {
        var ret = 0;
        foreach (var item in Bugs)
        {
            ret += (((int)item.Key) + 1) * item.Value.Count;
        }
        return ret;
    }
    #endregion

    #region Action control
    float amt = 0;
    float level = 0;

    virtual protected void Action()
    {}

    virtual protected float CalcLevel()
    {
        var ret = 0;
        foreach (var item in Bugs)
        {
            ret += (((int)item.Key) + 1) * item.Value.Count;
        }
        return ret/10f;
    }

    void UpdateLevel()
    {
        level = CalcLevel();
        Debug.Log(gameObject.name + ": level " + level);
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

        level = CalcLevel();
        amt += level * Time.deltaTime;
        if (progressSlider != null)
        {
            progressSlider.value = Mathf.Min(amt, 1);
        }
        while (amt > 1) {
            amt -= 1;
            Action();
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


}
