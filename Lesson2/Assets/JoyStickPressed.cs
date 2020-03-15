using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickPressed : MonoBehaviour , IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector] public bool Pressed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = true;
    }
}
