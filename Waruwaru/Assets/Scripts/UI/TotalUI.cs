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
        //�����ʒu�Ɉړ�
        if (waitPoints.Count > 0)
            transform.position = waitPoints[0].position;

        StartCoroutine("MovePoint");
    }



    private IEnumerator MovePoint()
    {
        int nextCount = 1;

        while(nextCount < waitPoints.Count)
        {
            //���̖ڕW�֋߂Â�
            Vector3 vec = waitPoints[nextCount].transform.position - transform.position;

            //������x�߂Â����玟�̃|�C���g��ڎw��
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
