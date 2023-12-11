using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottedLineData : MonoBehaviour
{
    private GameObject impactPointMarker = null;
    private List<GameObject> dotPointMarkerList = new List<GameObject>();
    private float dotInterval = 0.0f;

    public void SetImpactPointMarker(GameObject impactPointMarker) { this.impactPointMarker = impactPointMarker; }
    public void AddDotPointMarkerList(GameObject dotPointMarker) { this.dotPointMarkerList.Add(dotPointMarker); }
    public void SetDotInterval(float dotInterval) { this.dotInterval = dotInterval; }
    public GameObject GetImpactPointMarker() { return impactPointMarker; }
    public List<GameObject> GetDotPointMarkerList() { return dotPointMarkerList; }
    public float GetDotInterval() { return dotInterval; }
}
