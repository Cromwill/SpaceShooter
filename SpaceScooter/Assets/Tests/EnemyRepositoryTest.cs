using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class EnemyRepositoryTest : MonoBehaviour {

    public List<EnemyTest> EnemyRep = new List<EnemyTest>();
    public PathPointRepository Repository;

    private float RespawnTime;

    void Start ()
    {
		foreach(var t in GetComponentsInChildren<EnemyTest>())
        {
            EnemyRep.Add(t);
        }
	}
	

	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var en = GetEnemyTest();
            if(en != null)
            {
                en.StartMove(Repository.GetPath().GetEnumerator());
                //en.StartMove(ScriptableObject.CreateInstance<MoveToPointTest>());
               
            }
        }
	}



    public EnemyTest GetEnemyTest()
    {
        return EnemyRep.FirstOrDefault(a => a.Ready == true);
    }

    public EnemyTest GetEnemyTest1()
    {
        foreach(EnemyTest en in EnemyRep)
        {
            if (en.Ready)
            {
                return en;
            }
        }

        return null;
    }
    
}
