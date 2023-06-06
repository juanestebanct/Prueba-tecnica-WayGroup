using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float  mouseSensity = 22.0f;

    public Transform Body;

    public Transform camara;

    private float rotacion = 0;



    private void Start()
    {
        Rotation();
    }
    public void Update()
    {
        Rotation();
    }
    public void Rotation()
    {
        float mousex = Input.GetAxis("Mouse X") * mouseSensity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mouseSensity * Time.deltaTime;

          

        Body.Rotate(Vector3.up*mousex);
        if (mousey != 0)
        {
            float angle = camara.localEulerAngles.x - mousey ;
            camara.localEulerAngles=  Vector3.right * angle;
        }


    }
}
