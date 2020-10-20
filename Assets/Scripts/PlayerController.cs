using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;

    [SerializeField]
    private Transform playerPointer;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float speedMultiplier;

    void Start()
    {
        joystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
    }

    private void FixedUpdate()
    {
        Controller();
    }

    private void Controller()
    {
        speed = new Vector2(joystick.Horizontal, joystick.Vertical).magnitude * speedMultiplier;

        if (joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
            playerPointer.position = new Vector3(joystick.Horizontal + transform.position.x, playerPointer.position.y, joystick.Vertical + transform.position.z);

            transform.LookAt(new Vector3(playerPointer.position.x, 0, playerPointer.position.z));

            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
