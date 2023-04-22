using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerComponent : MonoBehaviour
{
    public float moveSpeed;
    public float aimDisplayLength;
    public Transform asteroidContainer;
    CapsuleCollider2D playerCollider;
    LineRenderer lr;
    Rigidbody2D rb;
    Vector3 joystickInput;
    float currentMoveSpeed;
    public bool isShooting;

    Animator animator;


    private void Awake()
    {
        playerCollider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        animator = GetComponent<Animator>();
        
    }
    private void Update()
    {
        currentMoveSpeed = moveSpeed;
        if (joystickInput != Vector3.zero)
        {
            Quaternion temp = new Quaternion(0f, 0f, Quaternion.LookRotation(joystickInput, Vector3.up).y, -Quaternion.LookRotation(joystickInput, Vector3.up).w);
            transform.rotation = temp;
            animator.SetBool("isMoving", true);
            transform.position += transform.up * currentMoveSpeed * Time.deltaTime;
        }
        else 
        {
            animator.SetBool("isMoving", false);
            transform.rotation = Quaternion.identity;
        }
        

        if (isShooting)
        {
            ShootingMode();
        }
    }
    void ShootingMode()
    {
        moveSpeed = 0;
        foreach (GameObject ast in asteroidContainer)
        {
            ast.GetComponent<AsteroidComponent>().SwitchSpeed("slow");
        }
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, (transform.position + joystickInput) * aimDisplayLength);
    }
    public void AimMove(InputAction.CallbackContext context)
    {
        Vector2 temp = context.ReadValue<Vector2>();
        if (temp != Vector2.zero)
            joystickInput = new Vector3(temp.x, 0, temp.y);
        else joystickInput = Vector3.zero;
    }
    
    private void OnCollisionEnter2D(Collision2D asteroid)
    {
        isShooting = true;
    }
    
    void Shoot(InputAction.CallbackContext shoot)
    {

    }
}
