using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public int rotateSpeed;

    void Start()
    {
        rotateSpeed = 1;
    }

    void Update()
    {
        transform.Rotate(rotateSpeed, 0, 0, Space.World);
    }
}
