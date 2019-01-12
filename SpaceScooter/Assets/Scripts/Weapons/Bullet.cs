using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IWeapons
{
    public int Damage;
    public float MoveSpeed;
    public bool isFire = false;
    public int WiaponsIndex;
    public float FireSpeed;

    public float TimeLife;


    private Transform _selfTransform;
    private float _currentTimeLife;
    private Vector3 _startPosition;

	void Start ()
    {
        _selfTransform = GetComponent<Transform>();
        _startPosition = GetComponentInParent<Transform>().position;
	}
	

	void Update ()
    {
		if(isFire)
        {
            Fire();
        }
	}

    public void Fire()
    {
        _selfTransform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);
        _currentTimeLife += Time.deltaTime;
        if(_currentTimeLife >= TimeLife)
        {
            FinishFire();
        }
    }

    public void FinishFire()
    {
        isFire = false;
        _selfTransform.position = _startPosition;
    }

    public float GetFireSpeed()
    {
        return FireSpeed;
    }

    public int GetDamage()
    {
        return Damage;
    }

    public int GetIndex()
    {
        return WiaponsIndex;
    }

    public bool IsUsing()
    {
        return isFire;
    }

    public void UseThat(Vector3 position, Quaternion q)
    {
        _selfTransform.position = position;
        _selfTransform.rotation = q;
        _currentTimeLife = 0;
        isFire = true;
    }
}
