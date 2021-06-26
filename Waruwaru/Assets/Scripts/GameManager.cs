using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score;

    [SerializeField]
    int m_kobushiSwingMaxNum = 10;

    GameObject m_kobushi = null;

    bool m_bResult = false;

    // Start is called before the first frame update
    void Start()
    {
        m_kobushi = GameObject.Find("Kobushi");
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Kobushi kobushi = m_kobushi.GetComponent<Kobushi>();

        if (m_kobushiSwingMaxNum == kobushi.GetSwingNum() && kobushi.GetState() == Kobushi.KobushiState.idle)
        {
            GameObject.Find("Main Camera").GetComponent<ResultCamera>().ResultStart();

            m_bResult = true;
        }
    }

    public bool IsResult()
    {
        return m_bResult;
    }
}
