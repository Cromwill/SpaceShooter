using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    private Transform _selfTransform;
    private MoveToPointTest _move;

    public bool IsMove = false;
    public bool IsStopPoint = false;
    public bool Ready = true;

    public float Speed;

	void Start ()
    {
        _selfTransform = GetComponent<Transform>();
        _move = GetComponent<MoveToPointTest>();
	}
	

	void Update ()
    {
		
	}

    public void Move(Vector3 start, Vector3 finish)
    {
        _selfTransform.position = Vector3.MoveTowards(start, finish, Speed * Time.deltaTime);
    }

    public void StartMove(IEnumerator<StopPoint> path)
    {
        _move.FillingDate(path);

        IsMove = true;
        Ready = false;
    }

    public Vector3 GetPosition()
    {
        return _selfTransform.position;
    }
}
