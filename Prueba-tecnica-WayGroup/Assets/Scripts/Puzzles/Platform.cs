using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("platform configuration")]

    [SerializeField] private Transform[] Point;
    [SerializeField] private int indexPoint;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 1f;

    private Vector3 currentTarget;
    private bool moving;
    private int MaximumPathsize;

    #region Private fuctions 
    private void Awake()
    {
        indexPoint = 0;
        MaximumPathsize = Point.Length;
        currentTarget = Point[indexPoint].position;
        moving = true;
    }

    private void Update()
    {
        MovePlatform();
    }
    /// <summary>
    /// Se encarga de mover la plataforma hasta llegar al punto 
    /// </summary>
    private void MovePlatform()
    {
        if (!moving) return;

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        changePointPlatform();
    }
    /// <summary>
    /// Detecta si llego al punto y cambia de punto 
    /// </summary>
    private void changePointPlatform()
    {
        if (transform.position == currentTarget)
        {
            if (indexPoint < MaximumPathsize - 1) indexPoint++;
            else indexPoint=0;

            currentTarget = Point[indexPoint].position;
            moving = false;
            Invoke("StartMoving", waitTime);
        }
        
    }
    private void StartMoving()
    {
        moving = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Transform>().SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Transform>().SetParent(null);
        }
    }

    #endregion
}
