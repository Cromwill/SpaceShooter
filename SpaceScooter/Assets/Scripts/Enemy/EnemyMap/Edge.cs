using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public NavigationNode From;
    public NavigationNode ToNode;

    public Edge(NavigationNode from, NavigationNode toNode)
    {
        From = from;
        ToNode = toNode;
    }

    public NavigationNode Not(NavigationNode node)
    {
        return node == From ? ToNode : From;
    }
}
