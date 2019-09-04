﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    [RequireComponent(typeof(CharacterController))]
    [AddComponentMenu("Control Script/FPS Input")]


public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    private CharacterController _charController;
    public float gravity = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
