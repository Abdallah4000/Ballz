using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherPreview : MonoBehaviour
{
    LineRenderer lineRenderer ;
    Vector3 dragStartPoint;
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetStartPoint (Vector3 worldPoint) {

        dragStartPoint = worldPoint;
        lineRenderer.SetPosition(0,worldPoint);
        
    }

    public void SetEndPoint (Vector3 worldPoint) {

        Vector3 offest = worldPoint - dragStartPoint;
        
        Vector3 endPoint = transform.position + offest ;

        lineRenderer.SetPosition(1,endPoint);
        
    }

}
