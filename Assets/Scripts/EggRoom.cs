using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggRoom : Room
{
    [SerializeField]
    Bug spawnBug;

    protected override void Action()
    {
        Instantiate(spawnBug);
        base.Action();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override float CalcLevel()
    {
        return base.CalcLevel();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
