using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public Transform rodTransform;
    public Transform bobberTransform;

    public LineRenderer lineRenderer;

    public int pointCount = 10;

    public FishingRodData data;




    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = pointCount + 1;

        lineRenderer.startColor = data.lineColor;
        lineRenderer.endColor = data.lineColor;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rodPosition = rodTransform.position;
        Vector3 bobberPosition = bobberTransform.position;

        // Set thge first poiint
        //lineRenderer.SetPosition(0, rodPosition);

        Vector3 delta = bobberPosition - rodPosition;
        float distance = delta.magnitude;

        float distanceInterp = (distance - data.minCurveDistance) / (data.maxCurveDistance - data.minCurveDistance);
        float curveStrength = Mathf.Lerp(data.minCurveStrength, data.maxCurveStrength, distanceInterp);

        // Make up points inbetween
        for (int i = 0; i <= pointCount; i++)
        {
            float interp = i / ((float) pointCount);

            Vector3 position = Vector3.Lerp(rodPosition, bobberPosition, interp);

            float curveValue = data.lineCurve.Evaluate(interp);
            curveValue *= curveStrength;

            position.y -= curveValue;

            lineRenderer.SetPosition(i, position);
        }

        // Set the last point
        //lineRenderer.SetPosition(1, bobberPosition);
    }
}
