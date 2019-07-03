using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyGrid : MonoBehaviour
{
    //Ce script a pour objectif de créer la grille

    //grid specifics
    [SerializeField]
    public int rows;
    [SerializeField]
    public int cols;
    [SerializeField]
    private Vector2 gridSize;
    [SerializeField]
    private Vector2 gridOffset;

    //about cells
    [SerializeField]
    private GameObject cellObject;
    private Sprite cellSprite;
    private Vector2 cellSize;
    private Vector2 cellScale;

    [SerializeField]
    private float espacement = 100;

    public delegate void DoWhenFInishedToCreatAllCase();
    public event DoWhenFInishedToCreatAllCase whenJustFinished; //Evenement s'activant lorsque la grille vient juste de se construire

    void Start()
    {
        cellSprite = cellObject.GetComponent<Image>().sprite;
        InitCells(); //Initialize all cells
    }

    //Drawn Cells
    void InitCells()
    {
        //catch the size of the sprite
        cellSize = cellSprite.bounds.size;

        //get the new cell size -> adjust the size of the cells to fit the size of the grid
        Vector2 newCellSize = new Vector2(gridSize.x / (float)cols, gridSize.y/ (float)rows);

        //Get the scales so you can scale the cells and change their size to fit the grid
        cellScale.x = newCellSize.x / cellSize.x;
        cellScale.y = newCellSize.y / cellSize.y;

        cellSize = newCellSize; //the size will be replaced by the new computed size, we just used cellSize for computing the scale

        cellObject.transform.localScale = new Vector2(cellScale.x, cellScale.y);

        //fix the cells to the grid by getting the half of the grid and cells add and minus experiment
        gridOffset.x = -(gridSize.x / 2) + cellSize.x / 2;
        gridOffset.y = -(gridSize.y / 2) + cellSize.y / 2;

        //fill the grid with cells by using Instantiate
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                //add the cell size so that no two cells will have the same x and y position
                Vector2 pos = new Vector2(col * espacement * cellSize.x + gridOffset.x + transform.position.x, row * espacement * cellSize.y + gridOffset.y + transform.position.y);

                //instantiate the game object, at position pos, with rotation set to identity
                GameObject cO = Instantiate(cellObject, pos, Quaternion.identity) as GameObject;

                //set the parent of the cell to GRID so you can move the cells together with the grid;
                cO.transform.parent = transform;
            }
        }

        whenJustFinished?.Invoke(); //Permet d'invoquer l'evenement lorsque toutes les cases sont crée

        //destroy the object used to instantiate the cells
        //Destroy(cellObject);
    }

    //so you can see the width and height of the grid on editor
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, gridSize);
    }
}

