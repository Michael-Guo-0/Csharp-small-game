using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // get target position
    [SerializeField] private Transform target;
    [SerializeField] float smoothing;
    // set camera move bound
    [SerializeField] Vector2 maxPosition;
    [SerializeField] Vector2 minPosition;

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            // camera position has Z axis, but target position Z always 0, so it should be 
            // keep camera Z its own
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Limit the range that the x-axis can move
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            // Limit the range that the y-axis can move
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            // The value returned each time is a certain distance from A to B.
            // if smoothing is 0.1, which means it return 1/10 of the distance between A and B.
            // Cause the effect of dragging and moving slowly.
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
