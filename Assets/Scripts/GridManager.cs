using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public List<Image> gridBishop = new();
    public List<Image> gridRock = new();
    public List<Image> gridDragon = new();
    public List<Image> gridKnight = new();

    public Sprite emptyZone;

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
        if(gridBishop.Count == 3)
        {
            foreach(Image element in gridBishop)
            {
                element.sprite = emptyZone;
                element.GetComponent<GridElement>().canChange = true;
            }
            gridBishop.Clear();
        }
        if(gridRock.Count == 3)
        {
            foreach(Image element in gridRock)
            {
                element.GetComponent<Image>().sprite = emptyZone;
                element.GetComponent<GridElement>().canChange = true;
            }
            gridRock.Clear();
        }
        if(gridKnight.Count == 3)
        {
            foreach(Image element in gridKnight)
            {
                element.GetComponent<Image>().sprite = emptyZone;
                element.GetComponent<GridElement>().canChange = true;
            }
            gridKnight.Clear();
        }
        if(gridDragon.Count == 3)
        {
            foreach(Image element in gridDragon)
            {
                element.GetComponent<Image>().sprite = emptyZone;
                element.GetComponent<GridElement>().canChange = true;
            }
            gridDragon.Clear();
        }
    }
}
