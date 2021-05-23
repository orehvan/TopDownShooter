using UnityEngine;

public class Grid<TGridObject>
{
    private TGridObject[,] _gridArray;
    
    public int Width { get; set; }
    public int Height { get; set; }
    public float CellSize { get; set; }

    /*public TGridObject[,] GridArray
    {
        get
        {
            
        }

        set
        {
            
        }
    }*/
}