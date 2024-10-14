using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public int width = 8;
    public int height = 8;

    public ChessTile tilePrefab;

    public List<List<ChessTile>> tileList;

    public ChessTile[,] tileArray;


    // Start is called before the first frame update
    void Start()
    {
        tileArray = new ChessTile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                ChessTile newTile = Instantiate(tilePrefab);

                Vector3 newPosition = new Vector3(x, 0, y);
                newTile.transform.localPosition = newPosition;

                tileArray[x, y] = newTile;
                newTile.SetTilePosition(x, y);
            }
        }
    }
}
