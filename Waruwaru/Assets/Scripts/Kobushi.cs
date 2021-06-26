using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kobushi : MonoBehaviour
{
    public enum KobushiState
    {
        idle,
        swing,
        end,
    }

    KobushiState m_state = KobushiState.idle;


    Vector3 m_offsetPos;

    [SerializeField]
    float m_speed = 1.0f;

   int m_swingNum = 0;

    [SerializeField]
    float m_swingEndPosY = -5.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_offsetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Operation();
        switch (m_state)
        {
            case KobushiState.idle:
                Idle();
                break;

            case KobushiState.swing:
                Swing();
                break;

            case KobushiState.end:
                End();
                break;
        }

    }

    //キーボード操作
    void Operation()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(m_state == KobushiState.idle)
            {
                m_state = KobushiState.swing;

                m_swingNum++;
            }
        }
    }

    //振り下ろし
    void Swing()
    {
        transform.position -= new Vector3(0, m_speed * Time.deltaTime, 0);

        if(transform.position.y < m_swingEndPosY)
        {
            m_state = KobushiState.end;
        }
    }

    void Idle()
    {

    }

    //戻ってくる
    void End()
    {
        transform.position += new Vector3(0, m_speed * Time.deltaTime, 0);

        if(transform.position.y > m_offsetPos.y)
        {
            transform.position = m_offsetPos;
            m_state = KobushiState.idle;
        }
    }


//=====================================================================================
    
    public int GetSwingNum()
    {
        return m_swingNum;
    }

    public KobushiState GetState()
    {
        return m_state;
    }

}
