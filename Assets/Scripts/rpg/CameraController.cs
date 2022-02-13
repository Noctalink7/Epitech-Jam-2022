using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform focus;
    public float smooth;

    void Start()
    {

    }

    void LateUpdate()
    {
        if(transform.position != focus.position)
        {
            Vector3 focusPos = new Vector3(focus.position.x, focus.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, focusPos, smooth);
        }
    }
}