using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedScore : MonoBehaviour
{
    //ステータス
    [SerializeField] ScoreManager.SCORE_TYPE type;
    [SerializeField] float power;
    [SerializeField] float flyRange;

    ScoreManager scoreMgr;
    int score = 0;




    // Start is called before the first frame update
    void Start()
    {
        //飛ぶ方向の設定
        float flyAngle = Random.Range(-flyRange, flyRange);
        Vector2 vec = new Vector2(0, 1);
        Vector2 flyVec = Quaternion.Euler(0, 0, flyAngle) * vec;
        GetComponent<Rigidbody2D>().AddForce(flyVec * power);

        //スコアマネージャーにスコアを追加する
        scoreMgr = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreMgr.AddScore(TypeToScore(type));
    }



    // Update is called once per frame
    void Update()
    {
        
    }





    //タイプによる変更
    int TypeToScore(ScoreManager.SCORE_TYPE type)
    {
        //タイプによる分岐
        switch(type)
        {
            case ScoreManager.SCORE_TYPE.SCORE_100:
                return 100;
            case ScoreManager.SCORE_TYPE.SCORE_50:
                return 50;
            case ScoreManager.SCORE_TYPE.SCORE_20:
                return 20;
            case ScoreManager.SCORE_TYPE.SCORE_M50:
                return -50;
        }

        return 0;
    }
}
