using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeApple : MonoBehaviour
{
    public ParticleSystem fxCollect;

    public void Collect()
    {
        // Play a particle
        Instantiate(fxCollect, transform.position, Quaternion.identity);

        // Destroy this object
        Destroy(gameObject);
    }
}
