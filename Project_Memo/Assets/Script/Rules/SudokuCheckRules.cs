using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuCheckRules : MonoBehaviour
{
    //Ce script a pour objectif de regarder si le joueur a une colonne de bon

    private CreatColumns myColumns; //Permet de récupérer la colonne réalisé

    void Start()
    {
        myColumns = FindObjectOfType<CreatColumns>();
    }

    void OnEnable()
    {
        FindObjectOfType<MyGrid>().whenJustFinished += AddRuleCheckerToAllCase;
    }
    void OnDisable()
    {
        FindObjectOfType<MyGrid>().whenJustFinished -= AddRuleCheckerToAllCase;
    }

    //Fonction permettant de vérifier qu'il y a une colonne gagnante (Fait des youpi uniquement à l'horizontal et non à la vertical)
    public void CheckEveryColumn()
    {
        int rows = FindObjectOfType<MyGrid>().rows; //Nombre de case en vertical
        int cols = FindObjectOfType<MyGrid>().cols; //Nombre de case en horizontal

        List<int> allNumberForOneColumn = new List<int>();
        bool columnIsCompleted = true;

        //Cette boucle vérifie uniquement l'horizontal
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                //On check la ligne du table
                //On ajoute toutes les valeurs de ce tableau dans une list d'int
                allNumberForOneColumn.Add(myColumns.columns[i, j].GetComponent<Attribue>().numberOfCase);
            }

            //On regarde si toutes les valeurs de la liste sont différente (boucle)
            for (int k = 0; k < allNumberForOneColumn.Count; k++)
            {
                for (int l = k+1; l < allNumberForOneColumn.Count; l++)
                {
                    if(allNumberForOneColumn[k] == allNumberForOneColumn[l])
                    {
                        columnIsCompleted = false;
                    }
                }
            }

            if(columnIsCompleted == true)
            {
                //Si c'est le cas, alors on execute une fonction
                Debug.Log("Youpi !!");
            }


            //On efface ensuite la list pour pouvoir recommencer l'opération
            allNumberForOneColumn.RemoveRange(0, allNumberForOneColumn.Count);

            columnIsCompleted = true;
            //On recommence ensuite la boucle de vérification
        }

        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                //On check la ligne du table
                //On ajoute toutes les valeurs de ce tableau dans une list d'int
                allNumberForOneColumn.Add(myColumns.columns[j, i].GetComponent<Attribue>().numberOfCase);
            }

            //On regarde si toutes les valeurs de la liste sont différente (boucle)
            for (int k = 0; k < allNumberForOneColumn.Count; k++)
            {
                for (int l = k + 1; l < allNumberForOneColumn.Count; l++)
                {
                    if (allNumberForOneColumn[k] == allNumberForOneColumn[l])
                    {
                        columnIsCompleted = false;
                    }
                }
            }

            if (columnIsCompleted == true)
            {
                //Si c'est le cas, alors on execute une fonction
                Debug.Log("Youpi !!");
            }


            //On efface ensuite la list pour pouvoir recommencer l'opération
            allNumberForOneColumn.RemoveRange(0, allNumberForOneColumn.Count);

            columnIsCompleted = true;
            //On recommence ensuite la boucle de vérification
        }
    }

    public void AddRuleCheckerToAllCase()
    {
        GameObject[] allCase = GameObject.FindGameObjectsWithTag("Case");
        for (int i = 0; i < allCase.Length; i++)
        {
            allCase[i].GetComponent<Attribue>().caseJustSelected += CheckEveryColumn;
        }
    }
}
