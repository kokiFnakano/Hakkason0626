using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public static bool startMove = false;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private float targetSize;
    [SerializeField] private float speed = 5.0f;

    private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!startMove)
            return;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * speed);
    }
}
