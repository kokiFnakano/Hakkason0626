using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedScore : MonoBehaviour
{
    //�X�e�[�^�X
    [SerializeField] ScoreManager.SCORE_TYPE type;
    [SerializeField] float power;
    [SerializeField] float flyRange;

    ScoreManager scoreMgr;
    int score = 0;




    // Start is called before the first frame update
    void Start()
    {
        //��ԕ����̐ݒ�
        float flyAngle = Random.Range(-flyRange, flyRange);
        Vector2 vec = new Vector2(0, 1);
        Vector2 flyVec = Quaternion.Euler(0, 0, flyAngle) * vec;
        GetComponent<Rigidbody2D>().AddForce(flyVec * power);

        //�X�R�A�}�l�[�W���[�ɃX�R�A��ǉ�����
        scoreMgr = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreMgr.AddScore(TypeToScore(type));
    }



    // Update is called once per frame
    void Update()
    {
        
    }





    //�^�C�v�ɂ��ύX
    int TypeToScore(ScoreManager.SCORE_TYPE type)
    {
        //�^�C�v�ɂ�镪��
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
