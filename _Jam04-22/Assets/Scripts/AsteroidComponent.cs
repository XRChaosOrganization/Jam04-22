using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidComponent : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, Vector3.zero,moveSpeed*Time.deltaTime);
    }
}
