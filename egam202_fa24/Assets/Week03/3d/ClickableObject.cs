using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    // Visual vairables
    public Renderer myRend;

    Color originalColor;
    public Color highlight;

    bool isHighlighted;

    private void Start()
    {
        // Remember the starting color (so we can switch back to it)
        originalColor = myRend.material.color;
    }

    public void Hover()
    {
        // Switch the color
        myRend.material.color = highlight;

        // "Flag" update to set us back
        isHighlighted = true;
    }

    private void Update()
    {
        // If we're highlighted, switch back to the original color
        if (isHighlighted)
        {
            isHighlighted = false;
            myRend.material.color = originalColor;
        }
    }

}
