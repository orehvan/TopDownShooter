using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public float speed;
    public Vector2 dir;

    private void FixedUpdate()
    {
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
    }
}
