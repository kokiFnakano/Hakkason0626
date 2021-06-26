using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaremonoMove : MonoBehaviour
{
    [SerializeField]
    float m_speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1.0f, 0.0f, 0.0f) * m_speed * Time.deltaTime;
    }
}
