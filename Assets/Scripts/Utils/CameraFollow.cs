using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed = 0.125f;

    private Vector3 desiredPosition;

    private void Start()
    {
        if (target)
        {
            target.gameObject.GetComponent<MovementScript>().notifySpin += updateOffset;
        }
    }

    private void FixedUpdate()
    {
        desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
    }

    private void updateOffset()
    {
        offset.x *= -1;
    }
}
