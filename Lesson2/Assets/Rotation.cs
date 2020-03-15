using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private Joystick joystick;

    private Vector3 previousPosition;

    

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        
        if(Input.GetMouseButton(0) )
        {
           
                Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);
            
            
                transform.position = target.position;
                cam.transform.position = target.position; // new Vector3();
            if (joystick.Pressed)
            {
                cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
                cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
            }
            cam.transform.Translate(new Vector3(0, 0, -20));
           
            

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
