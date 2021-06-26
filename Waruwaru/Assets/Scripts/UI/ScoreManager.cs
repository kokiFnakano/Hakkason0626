using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScoreManager : MonoBehaviour
{
    public enum SCORE_TYPE
    {
        SCORE_100,
        SCORE_50,
        SCORE_20,
        SCORE_M50
    };


    int totalScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void AddScore(int score) { totalScore += score; }
    public int GetScore() { return totalScore; }
}
