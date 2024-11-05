using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FishingRod", menuName = "ScriptableObjects/FishingRod", order = 1)]
public class FishingRodData : ScriptableObject
{
    public Color lineColor;

    public AnimationCurve lineCurve;
    public float minCurveStrength;
    public float maxCurveStrength;

    public float minCurveDistance;
    public float maxCurveDistance;
}
