using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPointTest : MonoBehaviour
{
    private IEnumerator<StopPoint> _pointPathEn;
    private EnemyTest _enemy;

    public Vector3 CurrentPoint;

    void Start ()
    {
        _enemy = GetComponent<EnemyTest>();
	}

	void Update ()
    {
        if(_enemy.IsMove)
        {
            Move();
        }

	}

    public void FillingDate(IEnumerator<StopPoint> pointPath)
    {
        _pointPathEn = pointPath;
        if(_pointPathEn != null)
        {
            _pointPathEn.MoveNext();
        }
    }

    private void Move()
    {
        if(_pointPathEn != null)
        {
            Debug.Log(_pointPathEn.Current);
            Debug.Log(_pointPathEn.Current.GetPosition());
            _enemy.Move(_enemy.GetPosition(), _pointPathEn.Current.GetPosition());

            if(_enemy.GetPosition() == _pointPathEn.Current.GetPosition())
            {
                if (!_pointPathEn.MoveNext()) Destroy(this, 0.0f);
            }
        }
    }
}
