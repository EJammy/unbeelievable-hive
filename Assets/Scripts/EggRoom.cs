using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggRoom : Room
{
    protected override void Action()
    {
        Singletons.gameManager.SpawnBug();
        base.Action();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override float CalcLevel()
    {
        return 0.05f + Mathf.Log(2*base.CalcLevel() + 1, 4000);
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
