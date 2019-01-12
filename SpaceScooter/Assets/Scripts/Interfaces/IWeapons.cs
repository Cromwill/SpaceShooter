using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapons
{
    int GetDamage();
    void Fire();
    int GetIndex();
    bool IsUsing();
    void UseThat(Vector3 position, Quaternion q);
    float GetFireSpeed();
}
