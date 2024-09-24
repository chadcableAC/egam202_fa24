using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoverButton : MonoBehaviour
{
    UpdateMover mover;
    Button button;

    public Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        // This will find the FIRST UpdateMover in the scene
        mover = FindObjectOfType<UpdateMover>();

        // This will get the Button script on OUR transform
        button = GetComponent<Button>();
    }

    void Update()
    {
        // Get the current direction
        Vector3 currentDirection = mover.GetDirection();

        // Turn the button on / off is we're matching
        bool isSame = currentDirection == moveDirection;
        button.interactable = !isSame;
    }

    // We're public so that other scripts can message us (Like the UI button we're attached to)
    public void OnPressed()
    {
        // Switch the mover to our direction when pressed
        mover.ChangeDirection(moveDirection);
    }
}
