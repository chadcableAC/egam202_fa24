using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessTile : MonoBehaviour
{
    public Renderer myRend;

    public Color odd = Color.white;
    public Color even = Color.black;


    public void SetTilePosition(int x, int y)
    {
        bool isOdd = (x % 2) == (y % 2);

        Color color = even;
        if (isOdd)
        {
            color = odd;
        }

        myRend.material.color = color;
    }
}
