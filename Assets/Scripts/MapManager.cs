using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    #region Fields
    private Vector2 _size;
    private Tile[,] _tileArray;
    #endregion

    #region Properties
    public Tile tileResource;
    public int Width { get; set; }
    public int Height { get; set; }
    public Tile[,] TileArray
    {
        get => _tileArray;
        set { _tileArray = value; }
    }
    public Vector2 Size
    {
        set
        {
            _size = value;
            Width = (int)value.x;
            Height = (int)value.y;
        }
        get => _size;
    }
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        TileArray = new Tile[Width, Height];
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                // TileArray = Instan
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
