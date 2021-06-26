using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int m_kobushiSwingMaxNum = 10;

    GameObject m_kobushi = null;

    // Start is called before the first frame update
    void Start()
    {
        m_kobushi = GameObject.Find("Kobushi");
    }

    // Update is called once per frame
    void Update()
    {
        Kobushi kobushi = m_kobushi.GetComponent<Kobushi>();

        if (m_kobushiSwingMaxNum == kobushi.GetSwingNum() && kobushi.GetState() == Kobushi.KobushiState.end)
        {
            //???U???g
            Debug.Log("???U???g???J??");
        }
    }
}
