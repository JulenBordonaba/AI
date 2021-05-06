using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ConnectionView : MonoBehaviour
{
    public static List<ConnectionView> conections = new List<ConnectionView>();

    public Vector3 startPosition;
    public Vector3 endPosition;
    public LineRenderer lineRenderer;


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetConection(Vector3 start, Vector3 end)
    {
        startPosition = start;
        endPosition = end;

        foreach (ConnectionView cv in conections)
        {
            //if (AreTheSame(this, cv))
            if (this == cv)
            {
                Destroy(gameObject);
                return;
            }
        }

        conections.Add(this);
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }
    
    public static bool operator ==(ConnectionView v1, ConnectionView v2)
    {
        bool isEqual = (Vector3.Distance(v1.startPosition, v2.startPosition) <= 0.0001f) && (Vector3.Distance(v1.endPosition, v2.endPosition) <= 0.0001f);
        bool isEqualInverted = (Vector3.Distance(v1.startPosition, v2.endPosition) <= 0.0001f) && (Vector3.Distance(v1.endPosition, v2.startPosition) <= 0.0001f);

        return (isEqual || isEqualInverted);
    }

    public static bool operator !=(ConnectionView v1, ConnectionView v2)
    {
        bool isEqual = (Vector3.Distance(v1.startPosition, v2.startPosition) <= 0.0001f) && (Vector3.Distance(v1.endPosition, v2.endPosition) <= 0.0001f);
        bool isEqualInverted = (Vector3.Distance(v1.startPosition, v2.endPosition) <= 0.0001f) && (Vector3.Distance(v1.endPosition, v2.startPosition) <= 0.0001f);

        return !(isEqual || isEqualInverted);
    }


}
