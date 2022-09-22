using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    BeeDefender defender;

    public TextMeshProUGUI beeCount;
    public TextMeshProUGUI honeyCount;

    void Awake()
	{
		DontDestroyOnLoad(gameObject);
		Singletons.gameManager = this;
	}

    // Start is called before the first frame update
    void Start()
    {
        beeCount.text = "x  " + Singletons.hivemind.GetBugAmount();
        honeyCount.text = "Honey:  $" + Statistics.honey;
    }

    // Update is called once per frame
    void Update()
    {
        beeCount.text = "x  " + Singletons.hivemind.GetBugAmount();
        honeyCount.text = "Honey:  $" + Statistics.honey;
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
