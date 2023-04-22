using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidComponent : MonoBehaviour
{
    public float normalmoveSpeed;
    public float slowMoveSpeed;
    public float currentMoveSpeed;
    public Rigidbody2D rb;
    public bool isLaunched;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentMoveSpeed = normalmoveSpeed;
    }
    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, currentMoveSpeed * Time.deltaTime);
    }

    public void SwitchSpeed(string _speed)
    {
        if (_speed == "slow")
        {
            currentMoveSpeed = slowMoveSpeed;
        }
        else
        {
            currentMoveSpeed = normalmoveSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (isLaunched && col.collider.CompareTag("Asteroid"))
        {
            Destroy(this.gameObject, 3f);
            Destroy(col.gameObject, 3f);
        }
    }
    
}
