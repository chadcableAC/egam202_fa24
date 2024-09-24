using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    public int xBound = 5;
    public int zBound = 10;

    Vector3 currentPosition;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
    }

    public bool CanMove(int amount, Vector3 direction)
    {
        currentPosition = transform.position;

        Vector3 newPosition = currentPosition + (amount * direction);

        bool isInBoundX = newPosition.x <= xBound;
        bool isInBoundZ = newPosition.z <= zBound;

        bool isInBothBounds = isInBoundX && isInBoundZ;

        return isInBothBounds;
    }

    public void Move(int amount, Vector3 direction)
    {
        transform.position += direction * amount;
    }
}
