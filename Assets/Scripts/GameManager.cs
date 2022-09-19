using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    BeeDefender defender;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		Singletons.gameManager = this;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {

        var target = Singletons.hivemind.LastBug(BugType.lvl0);
        if (target != null)
        {
            var spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPos.z = Camera.main.nearClipPlane;
            target.WorkRoom = null;
            Instantiate(defender, spawnPos, Quaternion.identity);
        }
    }
}
