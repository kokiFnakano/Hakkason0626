using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TotalScore : MonoBehaviour
{
    ScoreManager scoreMgr;

    Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        //合計スコアをテキストに書き起こす
        scoreMgr = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        scoreText = GetComponent<Text>();
        scoreText.text = scoreMgr.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreMgr.GetScore().ToString();
    }
}
