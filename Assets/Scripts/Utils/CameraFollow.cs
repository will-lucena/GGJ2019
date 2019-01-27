using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed = 0.125f;

    private Vector3 desiredPosition;

    private void FixedUpdate()
    {
        if (isOutOfBounds(target))
        {
            desiredPosition = target.position + offset;
        }
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
    }

    private bool isOutOfBounds(Transform target)
    {
        float xDistance = Mathf.Abs(transform.position.x + target.position.x);
        float yDistance = Mathf.Abs(transform.position.y + target.position.y);
        return xDistance > offset.x || yDistance > offset.y;
    }
}
