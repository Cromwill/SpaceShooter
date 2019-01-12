using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Speed;
    public int Damage;
    public int Life;
    public int EnemyIndex;
    public bool IsMove = false;
    public bool Ready = true;


    private bool isLife = true;
    private bool isFirePosition = false;
    
    
    
    private Transform _selfTransform;
    private MoveToPoints _move;
    private LifeHandler _selfLifeHandler;

    void Start ()
    {
        _selfTransform = GetComponent<Transform>();
        _move = GetComponent<MoveToPoints>();
        _selfLifeHandler = GetComponent<LifeHandler>();

        _selfLifeHandler.FillingHandler(Life, 0, GetComponent<CapsuleCollider2D>());
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
        if (path != null)
        {
            _move.FillingDate(path);

            IsMove = true;
            Ready = false;
        }
    }

    public Vector3 GetPosition()
    {
        return _selfTransform.position;
    }

    public void EnemyDeth()
    {
        isLife = false;
    }
}
