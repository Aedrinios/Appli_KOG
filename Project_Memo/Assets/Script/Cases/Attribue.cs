using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attribue : MonoBehaviour
{
    //Ce script a pour objectif de permettre de selectionner une case et d'y attribuer des choses//

    [HideInInspector]
    public int numberOfCase; //Variable qui permet d'attribuer un numéro à la

    public delegate void DoWhenSelectCase();
    public event DoWhenSelectCase caseJustSelected; //Evenement qui est déclanché quand on clique sur une case

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SelectTheCase); //Permet d'attribuer 
    }

    void OnEnable()
    {
        caseJustSelected += AttribueValue; 
    }
    void OnDisable()
    {
        caseJustSelected -= AttribueValue;
    }

    public void SelectTheCase()
    {
        caseJustSelected?.Invoke();
    }

    //Permet d'attribuer une valeur a une case en fonction de la valeur que l'on possède actuellement
    public void AttribueValue()
    {
        int number = FindObjectOfType<SelectNumber>().numberSelected;

        GetComponentInChildren<Text>().color = Color.white;
        GetComponentInChildren<Text>().text = "" + number;

        numberOfCase = number;
    }
}
