using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class EnemyRepository : MonoBehaviour
{
    public List<Enemy> EnemyArmy = new List<Enemy>();

    private void Start()
    {
        foreach(Enemy en in GetComponentsInChildren<Enemy>())
        {
            EnemyArmy.Add(en);
        }
    }

    public Enemy GetEnemy(int index)
    {
        return EnemyArmy.FirstOrDefault(a => a.Ready && a.EnemyIndex == index);
    }
}
