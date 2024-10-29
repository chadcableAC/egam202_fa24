using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleClicker : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Ray worldRay = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(worldRay, out RaycastHit hit))
            {
                AppleScript apple = hit.transform.GetComponent<AppleScript>();
                if (apple != null)
                {
                    apple.Click();
                }
            }
        }
    }
}
