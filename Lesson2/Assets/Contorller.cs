using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contorller : MonoBehaviour
{


    protected Joystick joyStick;
    public JoyButton joyButton;
    public JoyButton joyButton2;
    public JoyButton joyButton3;
    protected bool attack;
    protected bool active;
    protected bool passive;
    [SerializeField]
    private float movementSpeed = 2f;
    private float cuurentSpeed = 0f;
    private float speedSmoothVelocity = 0f;
    private float speedSmoothTime = 0.1f;
    private float rotationSpeed = 1.5f;
    private float gravity = 3f;

    private CharacterController controller = null;
    private Animator anim;
    private Transform mainCameraTransform = null;


    void Start()
    {
        joyStick = FindObjectOfType<Joystick>();
        
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        mainCameraTransform = Camera.main.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
        Active();
        Passive();
        
    }
    private void Move()
    {
        Vector2 movementInput = new Vector2(joyStick.Horizontal, joyStick.Vertical);

        Vector3 forward = mainCameraTransform.forward;
        Vector3 right = mainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 desireMoveDirection = (forward * movementInput.y + right * movementInput.x).normalized;
        Vector3 gravityVector = Vector3.zero;

        if(!controller.isGrounded)
        {
            gravityVector.y -= gravity;
        }


        if(desireMoveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desireMoveDirection),rotationSpeed);
        }

        float targetSpeed = movementSpeed * movementInput.magnitude;
        cuurentSpeed = Mathf.SmoothDamp(cuurentSpeed+2f, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        controller.Move(desireMoveDirection * cuurentSpeed * Time.deltaTime);
        controller.Move(gravityVector * Time.deltaTime);

        anim.SetFloat("vertical", 1 * movementInput.magnitude, speedSmoothTime, Time.deltaTime);

    }
    private void Attack()
    {
        if (!attack && joyButton.Pressed)
        {
            anim.SetBool("attack", true);
            attack = true;
        }
        if (attack && !joyButton.Pressed)
        {
            anim.SetBool("attack", false);
            attack = false;
        }
    }
    private void Active()
    {
        if(!active && joyButton2.Pressed)
        {
            anim.SetBool("active", true);
            active = true;
        }
        if(active && !joyButton2.Pressed)
        {
            anim.SetBool("active", false);
            active = false;
        }
    }
    private void Passive()
    {
        if(!passive && joyButton3.Pressed)
        {
            anim.SetBool("passive", true);
            passive = true;
        }
        if (passive && !joyButton3.Pressed)
        {
            anim.SetBool("passive", false);
            passive = false;
        }
    }
}
