using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll( Camera.main.ScreenPointToRay(Input.mousePosition) );
        bool hover2 = false;
        foreach (var hit in hits)
        {
            if (transform == hit.transform) hover2 = true;
        }

        // Debug.Log(hover + " " + hover2 + " " + (hits.Length != 0 && hits[0].transform == transform));

        if (hover2 && Input.GetKey(KeyCode.Mouse1))
        {
            Singletons.gameManager.SpawnBug();
            Destroy(transform.parent.gameObject);
        }
    }

    bool hover;
    void OnMouseEnter()
    {
        Debug.Log("Enter!");
        hover = true;
    }

    void OnMouseExit()
    {
        Debug.Log("Exit!");
        hover = false;
    }
}
