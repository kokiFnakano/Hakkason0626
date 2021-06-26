using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KobushiNum : MonoBehaviour
{
    Kobushi m_kobushi = null;
    GameManager m_gameManager = null;

    Text m_text = null;

    // Start is called before the first frame update
    void Start()
    {
        m_kobushi = GameObject.Find("Kobushi").GetComponent<Kobushi>();
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_text.text = (m_gameManager.GetKobushiSwingMaxNum() - m_kobushi.GetSwingNum()).ToString();
    }
}
