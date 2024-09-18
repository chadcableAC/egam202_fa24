using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeItemPlacer : MonoBehaviour
{
    // Item types
    public GameObject itemPrefab;

    public Vector2 placementSize = new Vector2(5, 5);
    public float placementRadius = 0.5f;

    public float placementAmountMin = 1;
    public float placementAmountMax = 5;

    public float placementAmountSnakeMin = 1;
    public float placementAmountSnakeMax = 10;

    PlayerSnake snake;
    List<GameObject> items = new();

    private void Start()
    {
        snake = FindObjectOfType<PlayerSnake>();
    }

    void Update()
    {
        // How many items should we have?
        int size = snake.size;
        float amountInterp = (size - placementAmountSnakeMin) / (placementAmountSnakeMax - placementAmountSnakeMin);
        float amount = Mathf.Lerp(placementAmountMin, placementAmountMax, amountInterp);

        int currentCount = 0;        
        for (int i = items.Count - 1; i >= 0; i--)
        {
            // If the object has been deleted, remove it from the list
            if (items[i] == null)
            {
                items.RemoveAt(i);
            }
            else
            {
                currentCount++;
            }
        }

        while (currentCount < amount)
        {
            // Find a place to add
            Vector3 originalPosition = transform.position;
            Vector3 offset = Vector3.zero;

            bool isValid = false;
            int attempts = 100;

            while (!isValid && attempts > 0)
            {
                offset.x = Random.Range(-placementSize.x, placementSize.x);
                offset.z = Random.Range(-placementSize.y, placementSize.y);

                // Is this space available?
                isValid = !Physics.CheckSphere(originalPosition + offset, placementRadius, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Collide);

                attempts--;
            }

            if (isValid)
            {
                GameObject newObject = Instantiate(itemPrefab, originalPosition + offset, Quaternion.identity);
                items.Add(newObject);

                currentCount++;
            }
        }
    }
}
