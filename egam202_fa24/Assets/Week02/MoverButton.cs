using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverButton : MonoBehaviour
{
    SimpleMover simpleMover;

    public float moveAmount;
    public Vector3 moveDirection;

    Button thisButton;



    // Start is called before the first frame update
    void Start()
    {
        simpleMover = FindObjectOfType<SimpleMover>();
        thisButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        int roundedAmount = Mathf.CeilToInt(moveAmount);//  (int)moveAmount;

        bool isMovePossible = simpleMover.CanMove(roundedAmount, moveDirection);
        thisButton.interactable = isMovePossible;
    }

    public void OnPressed()
    {
        int roundedAmount = Mathf.CeilToInt(moveAmount);

        simpleMover.Move(roundedAmount, moveDirection);
    }
}
