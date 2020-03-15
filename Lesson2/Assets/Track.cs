using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
   
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    private Vector3 previousPosition;
    // Start is called before the first frame update

    // Update is called once per frame


    void update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

         
            cam.transform.position = target.position; // new Vector3();

            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
           



            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
