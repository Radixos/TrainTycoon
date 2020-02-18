using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    public Transform mainCamera;

    private void LateUpdate()
    {
        Vector3 newPosition = mainCamera.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
