using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerComponent : MonoBehaviour
{
    public float moveSpeed;
    public float throwValue;
    public float aimDisplayLength;
    public float yOffsetGrab;
    public Transform asteroidContainer;
    public Transform handlingPoint;
    AsteroidComponent attachedAsteroid;
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
            Vector3 aimingPoint = new Vector3(transform.position.x + aimDisplayLength * transform.up.x, transform.position.y + aimDisplayLength * transform.up.y, 0f);
            lr.SetPosition(1,aimingPoint);
        }
        else
        {
            currentMoveSpeed = moveSpeed;
            
        }
    }
    void ShootingMode()
    {
        currentMoveSpeed = 0;
        foreach (Transform ast in asteroidContainer)
        {
            ast.GetComponent<AsteroidComponent>().SwitchSpeed("slow");
        }
        lr.SetPosition(0, transform.position);
        
    }
    void Shoot()
    {
        attachedAsteroid.transform.parent = null;
        attachedAsteroid.rb.AddForce(throwValue * this.transform.up, ForceMode2D.Impulse);
        attachedAsteroid.isLaunched = true;
        isShooting = false;
        lr.SetPosition(1, transform.position);
        foreach (Transform ast in asteroidContainer)
        {
            ast.GetComponent<AsteroidComponent>().SwitchSpeed("normal");
        }

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
        if (!isShooting)
        {
            isShooting = true;
            attachedAsteroid = asteroid.gameObject.GetComponent<AsteroidComponent>();
            asteroid.transform.parent = transform;
            asteroid.transform.position = handlingPoint.transform.position;
            attachedAsteroid.currentMoveSpeed = 0;
        }
        
    }
    
    public void Shoot(InputAction.CallbackContext shoot)
    {
        if (isShooting)
        {
            Shoot();
        }
    }
}
