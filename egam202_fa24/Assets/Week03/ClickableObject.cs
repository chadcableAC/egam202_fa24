using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public Renderer myRend;

    Color originalColor;
    public Color highlight;

    bool isHighlighted;


    private void Start()
    {
        originalColor = myRend.material.color;
    }

    public void Hover()
    {
        myRend.material.color = highlight;
        isHighlighted = true;
    }

    private void Update()
    {
        if (isHighlighted)
        {
            isHighlighted = false;
            myRend.material.color = originalColor;
        }
    }

}
