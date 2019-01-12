using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyRepository CurrentEnemyRepository;
    public List<PathPointRepository> EnemyPathWays = new List<PathPointRepository>();
    public int CurrentEnamyPath;
    public int CurrentEnemyIndex;

    public float RespawnTime = 1.0f;
    private float _respTimeCounter;
    private bool isRespawn = false;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            isRespawn = true;
        }

        if(isRespawn)
        {
            if(_respTimeCounter >= RespawnTime)
            {
                StartEnemyFight();
                _respTimeCounter = 0;
            }

            _respTimeCounter += Time.deltaTime;
        }
	}

    private void StartEnemyFight()
    {
        var en = CurrentEnemyRepository.GetEnemy(CurrentEnemyIndex);

        if(en != null)
        {
            //en.StartMove(EnemyPathWays[CurrentEnamyPath].GetPath().GetEnumerator());
            en.StartMove(EnemyPathWays[CurrentEnamyPath].GetPathList().GetEnumerator());
        }
        else
        {
            isRespawn = false;
            _respTimeCounter = 0;
        }
    }



}
