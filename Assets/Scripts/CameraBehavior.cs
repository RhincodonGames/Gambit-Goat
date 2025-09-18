using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;
    public Transform subject;

    public Vector2 deadZone = new Vector2(2f, 1.5f);
    public float minY = -2f;

    private Vector2 startPosition;

    private float startZ;

    private Vector3 cameraOffset;

    //Vector2 travel => (Vector2)cam.transform.position - startPosition;

    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
        cameraOffset = cam.transform.position - subject.position;
    }

    //public void Update()
    //{
    //    Vector2 newPos = startPosition + new Vector2(travel.x, 0);
    //    transform.position = new Vector3(newPos.x, startPosition.y, 0);
    //}

    public void LateUpdate()
    {
        Vector3 desired = cam.transform.position;

        // Horizontal Camera Movement
        if (Mathf.Abs(subject.position.x - cam.transform.position.x) > deadZone.x)
        {
            desired.x = subject.position.x + cameraOffset.x;
        }

        // Vertical Camera Movement
        if (Mathf.Abs(subject.position.y - cam.transform.position.y) > deadZone.y)
        {
            desired.y = Mathf.Max(subject.position.y + cameraOffset.y, minY);
        }

        cam.transform.position = desired;

        // Parallax Effect
        Vector2 travel = (Vector2)cam.transform.position - startPosition;
        Vector2 newPos = startPosition + new Vector2(travel.x, 0);          // Horizontal Movement Only
        transform.position = new Vector3(newPos.x, startPosition.y, startZ);
    }

}
