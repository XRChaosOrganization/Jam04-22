using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    public Vector3 moveDir;
    public float moveSpeed = 3;

    void Update()
    {
        if (moveDir != Vector3.zero)
        {
            Quaternion temp = new Quaternion(0f, 0f, Quaternion.LookRotation(moveDir, Vector3.up).y, -Quaternion.LookRotation(moveDir, Vector3.up).w);
            transform.rotation = temp;
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 temp = context.ReadValue<Vector2>();
        Debug.Log(temp);
        if (temp != Vector2.zero)
            moveDir = new Vector3(temp.x, 0, temp.y);
        else moveDir = Vector3.zero;

    }
}
