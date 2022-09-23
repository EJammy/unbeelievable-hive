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
        if (hover && Input.GetKeyDown(KeyCode.Mouse1))
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
        hover = false;
    }
}
