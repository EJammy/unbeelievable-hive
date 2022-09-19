using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hivemind : Room
{
	[SerializeField]
	Bug SpawnBug;

    protected override void Awake()
    {
		Singletons.hivemind = this;
        base.Awake();
    }

    protected override void Start()
    {
		Instantiate(SpawnBug, transform.position, transform.rotation);
		Instantiate(SpawnBug, transform.position, transform.rotation);
		Instantiate(SpawnBug, transform.position, transform.rotation);
		Instantiate(SpawnBug, transform.position, transform.rotation);
		Instantiate(SpawnBug, transform.position, transform.rotation);
		// Instantiate(SpawnBug, transform.position, transform.rotation);
		// Instantiate(SpawnBug, transform.position, transform.rotation);
		// Instantiate(SpawnBug, transform.position, transform.rotation);
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
