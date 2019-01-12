using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoints : MonoBehaviour
{
    private IEnumerator<StopPoint> _pointPathEn;
    private Enemy _enemy;

    public Vector3 CurrentPoint;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (_enemy.IsMove)
        {
            Move();
        }

    }

    public void FillingDate(IEnumerator<StopPoint> pointPath)
    {
        _pointPathEn = pointPath;
        if (_pointPathEn != null)
        {
            _pointPathEn.MoveNext();
        }
    }

    private void Move()
    {
        if (_pointPathEn != null)
        {
            _enemy.Move(_enemy.GetPosition(), _pointPathEn.Current.GetPosition());

            if (_enemy.GetPosition() == _pointPathEn.Current.GetPosition())
            {
                if (!_pointPathEn.MoveNext()) _pointPathEn = null;
            }
        }
    }
}
