using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectNumber : MonoBehaviour
{
    //Ce script a pour objectif de pouvoir prendre un numéro a jouer lorsque l'on clique sur un bouton qui correspond à un numéro 

    [HideInInspector]
    public int numberSelected = 0;

    public delegate void DoWhenSelectNumber();
    public event DoWhenSelectNumber numberJustSelected; //Evenement qui est déclanché quand on clique sur une case

    //Fonction devant être attribué au boutons qui permettent de selectionner un numero, permet de selectionner le numéro et de créer l'event, numberJustSelected
    public void SelectTheNumber(int number)
    {
        numberSelected = number;
        numberJustSelected?.Invoke(); //On réalise l'évènement
    }
}
