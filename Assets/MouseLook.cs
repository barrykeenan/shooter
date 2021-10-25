using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Control Script/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHorizontal = 9.0f;
    public float sensitivityVertical = 9.0f;

    public float minimumVertical = -45.0f;
    public float maximumVertical = 45.0f;

    private float _rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Disallow physics rotation on the player
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHorizontal, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVertical;
            _rotationX = Mathf.Clamp(_rotationX, minimumVertical, maximumVertical);

            transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
        }
        else
        {
            float rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityHorizontal;

            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVertical;
            _rotationX = Mathf.Clamp(_rotationX, minimumVertical, maximumVertical);

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
