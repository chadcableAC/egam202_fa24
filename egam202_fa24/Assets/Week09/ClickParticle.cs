using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickParticle : MonoBehaviour
{
    public ParticleSystem fx;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fx.Play();
        }

        if (Input.GetMouseButtonDown(2))
        {
            fx.Clear();
            fx.Stop();            
        }

        if (Input.GetMouseButtonDown(1))
        {
            fx.Stop();
        }
    }
}
