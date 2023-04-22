using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    public GameObject square;
    public float spawnRateTreshold;
    public Transform asteroidContainer;
    public GameObject asteroidPrefab;
    float spawnRate;
    public List<Vector2> corners;


    private void Awake()
    {
        GetCorners();
        spawnRate = spawnRateTreshold;
        square = this.gameObject;
    }
    private void Update()
    {
        spawnRate = spawnRate - Time.deltaTime;
        if (spawnRate <=0)
        {
            SpawnBall();
            spawnRate = spawnRateTreshold;
        }
    }
    void SpawnBall()
    {
        Vector3 rand = RandomSpawnLocation(Random.Range(0, 4), (float)Random.Range(0, 100)/100);
        Instantiate(asteroidPrefab, rand, Quaternion.identity, asteroidContainer);
    }
    Vector3 RandomSpawnLocation(int c,float r)
    {
        if (c == 3)
        {
            return Vector3.Lerp(corners[c], corners[0], r);
        }
        else
        {
            return Vector3.Lerp(corners[c], corners[c+1], r);
        }
    }
    void GetCorners()
    {
        Vector2 cornerA = new Vector2(this.transform.position.x - this.transform.localScale.x / 2, this.transform.position.y + this.transform.localScale.y / 2);
        Vector2 cornerB = new Vector2(this.transform.position.x + this.transform.localScale.x / 2, this.transform.position.y + this.transform.localScale.y / 2);
        Vector2 cornerC = new Vector2(this.transform.position.x + this.transform.localScale.x / 2, this.transform.position.y - this.transform.localScale.y / 2);
        Vector2 cornerD = new Vector2(this.transform.position.x - this.transform.localScale.x / 2, this.transform.position.y - this.transform.localScale.y / 2);
        corners.Add(cornerA);
        corners.Add(cornerB);
        corners.Add(cornerC);
        corners.Add(cornerD);
        
    }
}
