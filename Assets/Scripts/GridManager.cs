using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private Sprite emptyZone;
    [SerializeField]
    private GameObject popUpLose;

    [HideInInspector]
    public bool isAttacking;

    private List<Image> gridBishop = new();
    private List<Image> gridRock = new();
    private List<Image> gridDragon = new();
    private List<Image> gridKnight = new();

    /// <summary>
    /// Menambahkan grid yang terisi blok ke dalam list sesuai dengan tipe blok
    /// </summary>
    /// <param name="gridImage">Image dari blok</param>
    /// <param name="blockIndex">Nilai index blok</param>
    public void AddGridElementList(Image gridImage, int blockIndex)
    {
        switch (blockIndex)
        {
            case 0:
                gridBishop.Add(gridImage);
                break;
            case 1:
                gridRock.Add(gridImage);
                break;
            case 2:
                gridDragon.Add(gridImage);
                break;
            case 3:
                gridKnight.Add(gridImage);
                break;
        }

        CheckGridAmount();
    }

    private void CheckGridAmount()
    {
        //Jika nilai masing-masing list adalah 3 maka akan mengosongkan grid
        if(gridBishop.Count == 3)
        {
            foreach(Image element in gridBishop)
            {
                element.tag = "Empty Grid";
                element.sprite = emptyZone;
                element.GetComponent<GridElement>().isEmptyGrid = true;
            }
            gridBishop.Clear();
        }
        if(gridRock.Count == 3)
        {
            foreach(Image element in gridRock)
            {
                element.tag = "Empty Grid";
                element.sprite = emptyZone;
                element.GetComponent<GridElement>().isEmptyGrid = true;
            }
            gridRock.Clear();
        }
        if(gridKnight.Count == 3)
        {
            foreach(Image element in gridKnight)
            {
                element.tag = "Empty Grid";
                element.sprite = emptyZone;
                element.GetComponent<GridElement>().isEmptyGrid = true;
            }
            gridKnight.Clear();
        }
        if(gridDragon.Count == 3)
        {
            foreach(Image element in gridDragon)
            {
                element.tag = "Empty Grid";
                element.sprite = emptyZone;
                element.GetComponent<GridElement>().isEmptyGrid = true;
            }
            gridDragon.Clear();
        }
    }

    /// <summary>
    /// Fungsi jika pemain kalah
    /// </summary>
    public void LoseCondition()
    {
        //Mengaktifkan pop up lose dan mengatur time scale menjadi 0 agar game berhenti
        popUpLose.SetActive(true);
        Time.timeScale = 0;
    }
}
