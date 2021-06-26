using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalUI : MonoBehaviour
{
    [SerializeField] List<Transform> waitPoints;
    [SerializeField] float moveSpeed;
    [SerializeField] float lenge;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void GameOver()
    {
        //初期位置に移動
        if (waitPoints.Count > 0)
            transform.position = waitPoints[0].position;

        StartCoroutine("MovePoint");
    }



    private IEnumerator MovePoint()
    {
        int nextCount = 1;

        while(nextCount < waitPoints.Count)
        {
            //次の目標へ近づく
            Vector3 vec = waitPoints[nextCount].transform.position - transform.position;

            //ある程度近づいたら次のポイントを目指す
            if (vec.magnitude <= lenge)
            {
                yield return new WaitForSeconds(1.0f);
                nextCount++;
                continue;
            }
            else
            {
                transform.position += vec.normalized * moveSpeed;
                yield return null;
            }

            
        }
    }
}
