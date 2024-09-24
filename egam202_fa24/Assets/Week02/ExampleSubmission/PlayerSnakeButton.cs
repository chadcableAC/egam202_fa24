using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSnakeButton : MonoBehaviour
{
    PlayerSnake snake;
    Button button;

    public Vector3 moveDirection;
    public List<KeyCode> moveKeys;

    // Start is called before the first frame update
    void Start()
    {
        // This will find the FIRST UpdateMover in the scene
        snake = FindObjectOfType<PlayerSnake>();

        // This will get the Button script on OUR transform
        button = GetComponent<Button>();
    }

    void Update()
    {
        // Get the current direction
        Vector3 currentDirection = snake.GetDirection();

        // Turn the button on / off is we're matching
        float dot = Vector3.Dot(currentDirection, moveDirection);

        bool isMatch = false;
        if (dot > 0.5 ||
            dot < -0.5f)
        {
            isMatch = true;
        }

        // Also turn off if we're dead
        button.interactable = !isMatch && snake.isAlive;

        // Also listen for keyboard inputs?
        if (button.interactable)
        {
            foreach (KeyCode key in moveKeys)
            {
                if (Input.GetKeyDown(key))
                {
                    OnPressed();
                    break;
                }
            }
        }
    }

    // We're public so that other scripts can message us (Like the UI button we're attached to)
    public void OnPressed()
    {
        // Switch the mover to our direction when pressed
        snake.ChangeDirection(moveDirection);
    }
}
