using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NavigationRepository : MonoBehaviour {

    public GameObject Player;
    public List<Edge> Edges = new List<Edge>();
    public NavigationNode StartNode;
    public NavigationNode FinishNode;

    private IEnumerator<NavigationNode> en;
    private IEnumerator<Vector3> position;
    private List<Vector3> path = new List<Vector3>();

	void Start ()
    {
        //Player.GetComponent<Transform>().position = StartNode.GetPosition();

        foreach(NavigationNode node in FindObjectsOfType<NavigationNode>())
        {
            CreateEdge(node);
        }
        //en = FindPathMoreNear(StartNode, FinishNode).GetEnumerator();
        
    }
	

	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            
        }

        if(Input.GetKeyDown(KeyCode.K))
        {

            en.MoveNext();
            en.Current.ChangeVisited();
            path.Add(en.Current.GetPosition());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Shift pressed");
            if (position == null)
            {
                position = GetNextPosition().GetEnumerator();
                position.MoveNext();
            }

        }

        if (position != null)
        {
            PlayerMove(position.Current);

            if (Player.GetComponent<Transform>().position == position.Current)
            {
               if(!position.MoveNext()) position = null;
            }

        }

    }


    void PlayerMove(Vector3 nextPosition)
    {
        Transform playerTransform = Player.GetComponent<Transform>();
        playerTransform.position = Vector3.MoveTowards(playerTransform.position, nextPosition, Time.deltaTime * 2);
    }

    IEnumerable<Vector3> GetNextPosition()
    {

        for (int i = path.Count-1; i > -1; i--)
        {
            yield return path[i];
        }
    }

    


    void CreateEdge(NavigationNode current)
    {
        foreach(NavigationNode node in current.Incidients)
        {
            Edges.Add(new Edge(current, node));
        }
    }

    public IEnumerable<NavigationNode> GetIncidientsNodes(NavigationNode node)
    {

        return Edges.Where((e) => e.From == node || e.ToNode == node).Select((ed) => ed.Not(node)).ToList();
    }

    public List<NavigationNode> GetPathToWide() // путь в глубину
    {
        List<NavigationNode> path = new List<NavigationNode>();

        List<NavigationNode> history = new List<NavigationNode>();
        NavigationNode current = StartNode;
        Queue<NavigationNode> queue = new Queue<NavigationNode>();
        queue.Enqueue(StartNode);
        
        history.Add(current);

        while(queue.Count != 0)
        {
            current = queue.Dequeue();
            path.Add(current);

            foreach (NavigationNode incindent in GetIncidientsNodes(current))
            {
                if(!history.Contains(incindent))
                {
                    queue.Enqueue(incindent);
                    history.Add(incindent);
                }
            }
        }

        return path;
    }

    //public IEnumerable<NavigationNode> FindPathMoreNear(NavigationNode startNode, NavigationNode finishNode)
    //{
    //    Dictionary<NavigationNode, NavigationNode> dictionary = new Dictionary<NavigationNode, NavigationNode>();
    //    List<NavigationNode> history = new List<NavigationNode>();
    //    NavigationNode current = startNode;
    //    Queue<NavigationNode> queue = new Queue<NavigationNode>();
    //    queue.Enqueue(startNode);

    //    while(current !=  finishNode)
    //    {
    //        current = queue.Dequeue();

    //        foreach(NavigationNode incindent in GetIncidientsNodes(current))
    //        {

    //            if (!history.Contains(incindent))
    //            {
    //                queue.Enqueue(incindent);
    //                history.Add(incindent);
    //                dictionary.Add(incindent, current);
    //            }
    //        }

    //    }

    //    current = finishNode;

    //    while (current != startNode)
    //    {
    //        if(current == finishNode) yield return current;
    //        current = dictionary[current];
    //        yield return current;
    //    }
    //}

}
