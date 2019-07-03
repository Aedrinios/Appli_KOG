using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; // Pour réuppérer les infos de collision du raycast

        if (Physics.Raycast(r, out hit, Mathf.Infinity))
        {
            Debug.Log("Issou");
        }
    }
}
