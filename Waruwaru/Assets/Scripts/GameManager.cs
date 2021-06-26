using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int m_kobushiSwingMaxNum = 10;

    GameObject m_kobushi = null;

    bool m_bResult = false;

    // Start is called before the first frame update
    void Start()
    {
        m_kobushi = GameObject.Find("Kobushi");
    }

    // Update is called once per frame
    void Update()
    {
        Kobushi kobushi = m_kobushi.GetComponent<Kobushi>();

        if (m_kobushiSwingMaxNum == kobushi.GetSwingNum() && kobushi.GetState() == Kobushi.KobushiState.idle)
        {
            //GameObject.Find("Main Camera").GetComponent<ResultCamera>().ResultStart();
            CameraMove.startMove = true;
            WaremonoCreater.startGame = false;
            m_bResult = true;
        }
    }

    public bool IsResult()
    {
        return m_bResult;
    }

    public int GetKobushiSwingMaxNum()
    {
        return m_kobushiSwingMaxNum;
    }
}
