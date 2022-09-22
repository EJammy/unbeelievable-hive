using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

#region Serialized Variables
    [SerializeField]
    BeeDefender defender;

    public TextMeshProUGUI beeCount;
    public TextMeshProUGUI honeyCount;
#endregion

#region Unity Functions
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
        if (Input.GetKeyDown(KeyCode.Mouse0)) trySpawnBee();
    }
#endregion

#region Helper Functions
    bool checkPlacement(Vector3 pos)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(pos, 0.5f, Vector2.up, 0);
        foreach (var obj in hits)
        {
            // Debug.Log(obj.transform.tag);
            if (obj.transform.tag == "Room" || obj.transform.tag == "Occupied") return false;
        }
        return true;
    }

    void trySpawnBee()
    {
        var spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var target = Singletons.hivemind.LastBug(BugType.lvl0);
        if (checkPlacement(spawnPos) && target != null)
        {
            spawnPos.z = Camera.main.nearClipPlane;
            target.WorkRoom = null;
            Instantiate(defender, spawnPos, Quaternion.identity);
        }
    }
#endregion
}
