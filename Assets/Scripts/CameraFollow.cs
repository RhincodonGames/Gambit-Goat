using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    public float yMin = -1f;
    public float yMax = 1.7f;

    // Update is called once per frame
    void Update()
    {
        if (target.position.y >= yMin && target.position.y <= yMax)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }

        ////If goat falls below (like into abyss), reset y-axis of camera
        //if (target.position.y < yMin)
        //{
        //    Vector3 newPos = new Vector3(target.position.x, 0f, -10f);
        //    transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        //}
        //else
        //{
        //    // Normal follow with offset
        //    Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        //    transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        //}
    }
}
