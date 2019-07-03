using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatColumns : MonoBehaviour
{
    //Ce script a pour objectif de créer dans un tableau a double entrée, les colonnes

    [HideInInspector]
    public GameObject[,] columns = new GameObject[5,5]; //Tableau qui contient tous les gameObject "Case" par hauteur et largeur

    void OnEnable()
    {
        FindObjectOfType<MyGrid>().whenJustFinished += CreatAllColumn;
    }
    void OnDisable()
    {
        FindObjectOfType<MyGrid>().whenJustFinished -= CreatAllColumn;
    }

    //Fonction permettant de créer toutes les colonnes et de les stocker dans un tableau à double entré
    void CreatAllColumn()
    {
        int rows = FindObjectOfType<MyGrid>().rows; //Nombre de case à la vertical
        int cols = FindObjectOfType<MyGrid>().rows; //Nombre de case à l'horizontal

        GameObject[] allCase = GameObject.FindGameObjectsWithTag("Case");

        int numberCaseCheken = 0;

        //Permet de créer toutes les colonnes
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                columns[i,j] = allCase[numberCaseCheken];
                numberCaseCheken++;
            }
        }
    }
}
