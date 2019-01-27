using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(Input.GetAxis("Horizontal") + transform.position.x, transform.position.y, transform.position.z);
    }
}
