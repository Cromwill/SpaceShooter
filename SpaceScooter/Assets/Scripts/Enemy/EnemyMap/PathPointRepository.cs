using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class PathPointRepository : MonoBehaviour {

    public StopPoint StartPoint;

    public IEnumerable<StopPoint> GetPath()
    {
        if (!StartPoint.IsBusy)
        {
            List<StopPoint> path = new List<StopPoint>();

            List<StopPoint> history = new List<StopPoint>();
            StopPoint current;
            Queue<StopPoint> queue = new Queue<StopPoint>();

            history.Add(StartPoint);
            queue.Enqueue(StartPoint);

            while (queue.Count != 0)
            {
                current = queue.Dequeue();
                path.Add(current);

                foreach (StopPoint point in current.Incidients)
                {
                    if (!history.Contains(point) && !point.IsBusy)
                    {
                        queue.Enqueue(point);
                        history.Add(point);
                    }
                }
            }

            path.Last().IsBusy = true;
            return path;
        }

        return null;
    }

    public List<StopPoint> GetPathList()
    {
        if (!StartPoint.IsBusy)
        {
            List<StopPoint> path = new List<StopPoint>();

            List<StopPoint> history = new List<StopPoint>();
            StopPoint current;
            Queue<StopPoint> queue = new Queue<StopPoint>();

            history.Add(StartPoint);
            queue.Enqueue(StartPoint);

            while (queue.Count != 0)
            {
                current = queue.Dequeue();
                path.Add(current);

                foreach (StopPoint point in current.Incidients.Where(a => !a.IsBusy))
                {
                    if (!history.Contains(point))
                    {
                        queue.Enqueue(point);
                        history.Add(point);
                    }
                }
            }

            path.Last().IsBusy = true;
            return path;
        }

        return null;
    }

    public int GetCountPoints()
    {
        return GetPathList().Count;
    }
}
