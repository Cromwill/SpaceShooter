using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<IItems> PlayerItems = new List<IItems>();
    public List<IWeapons> PlayerWeapons = new List<IWeapons>();
    public Arsenal Arsenal;

    private int _currentItems = 0;
    private int _currentWeapons = 0;
    private float _weaponsCounter = 0;

    private void Update()
    {
        if(_weaponsCounter != 0)
        {
            _weaponsCounter -= Time.deltaTime;
            if (_weaponsCounter < 0) _weaponsCounter = 0;
        }
    }

    public void GetItems()
    {

    }

    public void GetWeapons(Vector3 position, Quaternion quaternion)
    {
        if(_weaponsCounter == 0)
        {
            _weaponsCounter = Arsenal.GetWeaponsFireSpeed(_currentWeapons);
            Arsenal.GetWeapons(position, _currentWeapons, quaternion);
        }
    }

    public void ChangeCurrentItem()
    {

    }

    public void ChangeCurrentWeapons()
    {

    }
}
