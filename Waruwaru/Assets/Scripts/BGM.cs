using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField]
    AudioClip m_mainBGM = null;
    [SerializeField]
    AudioClip m_resultBGM = null;

    AudioSource m_audioSource = null;

    GameObject m_gameManager = null;

    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.Play();

        m_gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(m_gameManager.GetComponent<GameManager>().IsResult())
        {
            if (m_audioSource.clip != m_resultBGM)
            {
                m_audioSource.clip = m_resultBGM;
                m_audioSource.Play();
            }
        }
    }
}
