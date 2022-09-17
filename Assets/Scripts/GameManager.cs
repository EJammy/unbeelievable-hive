using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	[SerializeField]
	Room _hivemind;
	public Room Hivemind
	{
		get { return _hivemind; }
	}

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
}
