using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountCase : MonoBehaviour
{
    //Script permettant de compter toutes les cases crées
    public void CountAllCase()
    {
        GameObject[] allCase = GameObject.FindGameObjectsWithTag("Case");
        for (int i = 0; i < allCase.Length; i++)
        {
            //allCase[i].GetComponent<Attribue>().numberOfCase = i;
            allCase[i].name = "Case " + i;
        }
    }

    void OnEnable()
    {
        FindObjectOfType<MyGrid>().whenJustFinished += CountAllCase;
    }

    void OnDisable()
    {
        FindObjectOfType<MyGrid>().whenJustFinished -= CountAllCase;
    }
}
