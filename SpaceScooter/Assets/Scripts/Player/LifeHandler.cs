using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHandler : MonoBehaviour
{
    public bool isFilling;
    public System.Action Deth;

    private int _unitLife;
    private int _unitArmor;

    private Collider2D _unitCollider2D;


    void Update ()
    {
		if(isFilling)
        {
            CheckContact();  
        }
	}

    public void FillingHandler(int life, int armor, Collider2D collider)
    {
        _unitLife = life;
        _unitArmor = armor;
        _unitCollider2D = collider;
        isFilling = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }

    private void CheckContact()
    {
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        Collider2D[] coll = new Collider2D[10];

        int count = _unitCollider2D.OverlapCollider(filter , coll);

        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                if(coll[i].tag == "Bullet")
                {
                    Bullet bullet = coll[i].GetComponent<Bullet>();

                    bullet.FinishFire();

                    TakeDamage(bullet.GetDamage());
                }

            }
        }
    }

    private void TakeDamage(int damage)
    {
        int loss = damage - _unitArmor;

        if(loss > 0)
        {
            _unitLife -= loss;
        }

        if(_unitLife < 0)
        {
            if(Deth != null)
            {
                Deth();
            }
        }

    }

}
