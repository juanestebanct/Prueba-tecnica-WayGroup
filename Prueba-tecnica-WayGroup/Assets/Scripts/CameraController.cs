using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] Transform Body;
    [SerializeField] private Camera camera;

    private float rotacion = 0;
    private void LateUpdate()
    {
        Rotation();
    }
    #region Private fuctions 
    /// <summary>
    /// funcion para cambiar la rotacion rotacion del cuerpo 
    /// </summary>
    public void Rotation()
    {
        Vector3 Dir = camera.transform.forward;
        Body.forward = new Vector3(Dir.x, 0, Dir.z).normalized;    
    }
    #endregion
}

