using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    public int CurrentScoreValue;
    public int Experience;



    public int GetScore()
    {
        return CurrentScoreValue;
    }

    public int GetExperience()
    {
        return Experience;
    }

}
