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
        return 0.04f + Mathf.Log(0.2f*base.CalcLevel() + 1, 3);
        // return 0.05f + 0.013f * base.CalcLevel();
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
