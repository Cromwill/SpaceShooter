using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatar : MonoBehaviour
{
    public float Speed;
    public float TurnSpeed;
    public PlayerInventory Inventory;

    private Transform _selfTransform;
    private PlayerContol _control;

	void Start ()
    {
        _selfTransform = GetComponent<Transform>();
        _control = GetComponent<PlayerContol>();
	}

	void Update ()
    {
	}

    public void Move(Vector3 tranlation, float turn)
    {
        Vector3 pos = _selfTransform.position + (tranlation * Speed * Time.deltaTime);

        _selfTransform.Rotate(0, 0, turn * Speed * Time.deltaTime);

        if (GameRect.GetGameRect().Contains(pos))
        {
            _selfTransform.Translate(tranlation * Speed * Time.deltaTime, Space.World);
            _selfTransform.Rotate(0, 0, -turn * TurnSpeed * Time.deltaTime);
        }
        else
        {
            _selfTransform.Translate(- tranlation * Speed * Time.deltaTime);
        }
    }

    public void Fire()
    {
        Debug.Log("Fire");
        Inventory.GetWeapons(_selfTransform.position, _selfTransform.rotation);
    }

    private void ChekcPosition(Vector3 tranlation)
    {
        Vector3 pos = _selfTransform.position + (tranlation * Speed * Time.deltaTime);

        if(!GameRect.GetGameRect().Contains(pos))
        {

        }
    }
}
