using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidComponent : MonoBehaviour
{
    public float normalmoveSpeed;
    public float slowMoveSpeed;
    public float currentMoveSpeed;
    private void Start()
    {
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
}
