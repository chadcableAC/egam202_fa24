using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntellisenseTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int thisIsClassTime = 0;
        thisIsClassTime += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("I've been pressed");
        }
    }
}
