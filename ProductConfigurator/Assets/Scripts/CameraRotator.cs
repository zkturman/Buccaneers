using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToRotateAround;
    [SerializeField]
    private float distanceFromObject;

    public void RotateCameraAround(float degreesToRotate)
    {
        transform.RotateAround(objectToRotateAround.transform.position, objectToRotateAround.transform.up, degreesToRotate);
    }

    private void LateUpdate()
    {
        RotateCameraAround(45 * Time.deltaTime);
    }
}
