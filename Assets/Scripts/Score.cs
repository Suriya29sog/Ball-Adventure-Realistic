using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Score", fileName = "Score")]
public class Score : ScriptableObject
{
    public int score;

    public void ResetScore()
    {
        score = 0;
    }

}
