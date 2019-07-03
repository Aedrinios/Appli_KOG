using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SelectNumber))]
public class ShowNumber : MonoBehaviour
{
    //Ce script à pour objectif d'afficher le numéro que l'on est en train de jouer sur un texte dans l'UI//

    public Text whereIsShow;

    private void OnEnable()
    {
        GetComponent<SelectNumber>().numberJustSelected += ShowMyNumber;
    }

    private void OnDisable()
    {
        GetComponent<SelectNumber>().numberJustSelected -= ShowMyNumber;
    }

    //Permet d'afficher le numéro en train d'être joué sur le texte mis en public
    public void ShowMyNumber()
    {
        whereIsShow.text = "" + FindObjectOfType<SelectNumber>().numberSelected;
    }
}
