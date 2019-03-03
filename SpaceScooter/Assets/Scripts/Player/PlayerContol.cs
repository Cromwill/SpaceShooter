using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContol : MonoBehaviour
{
    private PlayerAvatar _player;

	void Start ()
    {
        _player = GetComponent<PlayerAvatar>();

        foreach(var v in Input.GetJoystickNames())
        {
            Debug.Log(v);
        }
        
	}
	

	void Update ()
    {
        Move();

        Fire();
	}

    public void Fire()
    {
        if (Input.GetAxis("Joy_fire") < 0)
        {
            _player.Fire();
        }
    }

    public void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        float turn = Input.GetAxis("RightCrossX");

        _player.Move(new Vector3(moveX, moveY, 0).normalized, turn);
    }

    public Vector2 GetMinGameField()
    {
        return GameRect.GetGameRect().min;
    }

    public Vector2 GetMaxGameField()
    {
        return GameRect.GetGameRect().max;
    }
}
