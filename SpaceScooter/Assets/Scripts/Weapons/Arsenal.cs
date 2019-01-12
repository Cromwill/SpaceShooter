using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;


public class Arsenal : MonoBehaviour
{
    public List<IWeapons> ArsenalFilling = new List<IWeapons>();

	void Start ()
    {
		foreach(var weapons in GetComponentsInChildren<IWeapons>())
        {
            ArsenalFilling.Add(weapons);
        }
	}
	

	void Update ()
    {

	}

    public void GetWeapons(Vector3 position, int index, Quaternion q)
    {
        var weap = ArsenalFilling.FirstOrDefault(a => a.GetIndex() == index && !a.IsUsing());

        if(weap != null)
        {
            weap.UseThat(position, q);
        }
    }

    public float GetWeaponsFireSpeed(int index)
    {
        return ArsenalFilling.First(a => a.GetIndex() == index).GetFireSpeed();
    }
}


