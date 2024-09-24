using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeLengthUi : MonoBehaviour
{
    public TextMeshProUGUI text;

    PlayerSnake snake;
    int lastSize = -1;

    private void Start()
    {
        snake = FindObjectOfType<PlayerSnake>();
    }

    private void Update()
    {
        // Update the size
        if (snake != null)
        {
            // Only update the text when there's a change in size
            int size = snake.size;
            if (size != lastSize)
            {
                lastSize = size;
                text.text = "Score: " + size;
            }
        }
    }
}
