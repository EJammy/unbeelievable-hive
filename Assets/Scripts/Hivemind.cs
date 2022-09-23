using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hivemind : Room
{
    [SerializeField]
    Bug SpawnBug;

    [SerializeField]
    UpgradeMenu upgradeMenu;

    protected override void Awake()
    {
        Singletons.hivemind = this;
        base.Awake();
    }

    protected override void Start()
    {
        for (var i = 0; i < 30; i++)
            Singletons.gameManager.SpawnBug();
        // Instantiate(SpawnBug, transform.position, transform.rotation);
        // Instantiate(SpawnBug, transform.position, transform.rotation);
        // Instantiate(SpawnBug, transform.position, transform.rotation);
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void MouseAction()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            upgradeMenu.HandleMenu();
        }
    }
}
