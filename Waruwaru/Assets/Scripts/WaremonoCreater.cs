using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaremonoCreater : MonoBehaviour
{
    public static bool startGame = false;

    [SerializeField]
    List<GameObject> m_waremonoPrefabs = new List<GameObject>();
    [SerializeField] private AudioClip clip;

    Vector3 m_createPos;

    [SerializeField]
    float m_interval = 0;
    float m_time = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_createPos = transform.Find("CreatePos").position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startGame)
            return;

        if(m_time > m_interval)
        {
            AudioManager.Instance.PlaySE(clip);
            var tmp = Instantiate(m_waremonoPrefabs[Random.Range(0, m_waremonoPrefabs.Count)]);
            tmp.transform.position = new Vector3(m_createPos.x, m_createPos.y, m_createPos.z);

            m_time = 0;
        }

        m_time += Time.deltaTime;
    }
}
