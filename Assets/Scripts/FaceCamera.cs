﻿using UnityEngine;

[ExecuteInEditMode]
public class FaceCamera : MonoBehaviour
{
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
