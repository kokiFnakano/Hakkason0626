using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultCamera : MonoBehaviour
{
    bool m_bResultStart = false;

    [SerializeField]
    float m_speed = 0;

    Vector3 m_resultPos;

    // Start is called before the first frame update
    void Start()
    {
        m_resultPos = GameObject.Find("ResultPos").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_bResultStart)
        {
            transform.position -= new Vector3(0, 1, 0) * m_speed * Time.deltaTime;

            if(transform.position.y < m_resultPos.y)
            {
                m_bResultStart = false;

                transform.position = m_resultPos;
            }
        }
    }

    public void ResultStart()
    {
        m_bResultStart = true;
        
    }
}
