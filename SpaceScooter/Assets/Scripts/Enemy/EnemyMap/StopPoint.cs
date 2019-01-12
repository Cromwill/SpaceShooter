using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPoint : MonoBehaviour
{

    public List<StopPoint> Incidients = new List<StopPoint>();
    public bool IsBusy = false;
    private Transform _selfTransform;



    void Start ()
    {
        _selfTransform = GetComponent<Transform>();
        
	}

    private void OnDrawGizmos()
    {
        if (Incidients.Count > 0)
        {
            foreach (StopPoint point in Incidients)
            {
                Gizmos.DrawLine(transform.position, point.gameObject.transform.position);
            }
        }
    }

    public Vector3 GetPosition()
    {
        return _selfTransform.position;
    }
}
