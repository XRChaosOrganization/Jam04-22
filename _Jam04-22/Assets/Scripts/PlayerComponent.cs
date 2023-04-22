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
    Vector2 joystickInput;
    bool isShooting;
    private void Awake()
    {
        playerCollider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        transform.Translate(joystickInput * Time.deltaTime * moveSpeed);
        if (isShooting)
        {
            ShootingMode();
        }
    }
    void ShootingMode()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        foreach (GameObject ast in asteroidContainer)
        {
            ast.GetComponent<AsteroidComponent>().SwitchSpeed("slow");
        }
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, ((Vector2)transform.position + joystickInput) * aimDisplayLength);
    }
    public void AimMove(InputAction.CallbackContext move)
    {
        joystickInput = move.ReadValue<Vector2>();
    }
    
    private void OnCollisionEnter2D(Collision2D asteroid)
    {
        isShooting = true;
    }
    
    void Shoot(InputAction.CallbackContext shoot)
    {

    }
}
