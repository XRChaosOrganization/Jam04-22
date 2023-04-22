using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerComponent : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 mvt;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Move(InputAction.CallbackContext context)
    {
        mvt = context.ReadValue<Vector2>();
    }
    private void Update()
    {
        transform.Translate(mvt * Time.deltaTime * moveSpeed);
        
    }
}
