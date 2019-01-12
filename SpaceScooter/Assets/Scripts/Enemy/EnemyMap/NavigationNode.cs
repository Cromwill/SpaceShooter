using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationNode : MonoBehaviour
{
    
    public List<NavigationNode> Incidients = new List<NavigationNode>();
    public bool isVisited;

    private Vector3 _parantPosition;
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();

        _parantPosition = GetComponentInParent<Transform>().position;
    }

    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        if (Incidients.Count > 0)
        {
            foreach (NavigationNode node in Incidients)
            {
                Gizmos.DrawLine(transform.position, node.gameObject.transform.position);
            }
        }
    }

    public void ChangeVisited()
    {
        isVisited = true;
    }

    public Vector3 GetPosition()
    {
        if(_transform == null) _transform = GetComponent<Transform>();
        return _transform.position;
    }

    public Vector3 GetWorldPosition()
    {
        if (_transform == null) _transform = GetComponent<Transform>();
        //Debug.Log("Position - " + _transform.position);
        //Debug.Log("Parent Position - " + _parantPosition);


        Vector3 pos = _transform.position;
        return pos;
    }


}