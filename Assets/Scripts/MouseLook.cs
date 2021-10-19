using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes 
    {
        MouseXY=0,
        MouseX=1,
        MouseY=2
    }

    public RotationAxes axes = RotationAxes.MouseXY;
    public float HorizontalSensitivity = 9f;
    //public float VerticalSensitivity = 9f;

    //public float MinVertical = -45f;
    //public float MaxVertical = 45f;

    //private float RotationX=0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body)
            body.freezeRotation = true;
    }

    void Update()
    {
        switch (axes)
        {
            case RotationAxes.MouseXY:
                //{
                //    RotationX -= Input.GetAxis("Mouse Y") * VerticalSensitivity;
                //    RotationX = Mathf.Clamp(RotationX, MinVertical, MaxVertical);
                //    float delta = Input.GetAxis("Mouse X") * HorizontalSensitivity;
                //    float RotationY = transform.localEulerAngles.y + delta;
                //    transform.localEulerAngles = new Vector3(RotationX, RotationY, 0);
                //    break;
                //}
            case RotationAxes.MouseY:
                //{
                //    RotationX -= Input.GetAxis("Mouse Y") * VerticalSensitivity;
                //    RotationX = Mathf.Clamp(RotationX, MinVertical, MaxVertical);
                //    float RotationY = transform.localEulerAngles.y;
                //    transform.localEulerAngles = new Vector3(RotationX, RotationY, 0);
                //    break;
                //}
            case RotationAxes.MouseX:
                transform.Rotate(0, Input.GetAxis("Mouse X") * HorizontalSensitivity, 0);
                break;
        }
    }
}
