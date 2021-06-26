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
    int m_beforSwingNum = 0;

    [SerializeField]
    float m_swingEndPosY = -5.0f;

    List<GameObject> m_colList = new List<GameObject>();

    GameObject m_combo = null;

    bool m_bHit = false;

    [SerializeField]
    AudioClip[] m_audioClips;

    // Start is called before the first frame update
    void Start()
    {
        m_offsetPos = transform.position;

        m_combo = GameObject.Find("ComboManager");
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

                AudioManager.Instance.PlaySE(m_audioClips[0]);
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
        m_bHit = false;
    }

    //戻ってくる
    void End()
    {
        transform.position += new Vector3(0, m_speed * Time.deltaTime, 0);

        if(transform.position.y > m_offsetPos.y)
        {
            transform.position = m_offsetPos;
            m_state = KobushiState.idle;

            if (!(m_beforSwingNum + 1 == m_swingNum) && !m_bHit)
            {
                m_beforSwingNum = m_swingNum;
                m_combo.GetComponent<ComboManager>().ResetCombo();
                m_colList.Clear();

                Debug.Log("reset");
            }
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_bHit && m_state != KobushiState.swing)
            return;

        if(m_beforSwingNum + 1 == m_swingNum && !m_colList.Contains(collision.gameObject))
        {
            m_combo.GetComponent<ComboManager>().AddCombo();

            m_colList.Add(collision.gameObject);

            m_beforSwingNum = m_swingNum;

            m_bHit = true;
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
