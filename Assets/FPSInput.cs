using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;

    private CharacterController _charController;

    void Start()
    {
        // Access other components attached to the same object.
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Frame rate independent movement using deltaTime
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        // no collision detection
        // transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        // Limit diagonal movement to the same speed as movement along an axis.
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        // amount of time between frames
        movement *= Time.deltaTime;

        // convert local to global transform
        movement = transform.TransformDirection(movement);

        _charController.Move(movement); // accepts global transform
    }
}
