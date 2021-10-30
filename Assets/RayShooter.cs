using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();

        // Lock mouse cursor at centre of screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // runs every frame right after the 3D scene is rendered, resulting in
    // everything drawn during OnGUI() appearing on top of the 3D scene
    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // The middle of the screen is half its width and height.
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            // Create the ray at that position using ScreenPointToRay()
            Ray ray = _camera.ScreenPointToRay(point);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Debug.Log("Hit " + hit.point);
                StartCoroutine(SphereIndicator(hit.point));

                // GameObject hitObject = hit.transform.gameObject;
                // ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                // if (target != null)
                // {
                //     target.ReactToHit();
                // }
                // else
                // {
                //     StartCoroutine(SphereIndicator(hit.point));
                // }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
