using System.Collections.Generic;
using UnityEngine;

public class CommunicationWithCoin : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float spawnRate = 0.1f;
    public static float _coinAmount = 0.0f;

    private Vector3 whereToSpawn;
    private float nextSpawn = 0.0f;

    private List<Bounds> generatedBounds = new List<Bounds>();
    private GameObject createdObject;
    void GenerateObject()
    {
        whereToSpawn = new Vector3(Random.Range(-20, 0), 1.0f, Random.Range(-20, 0));
        createdObject = Instantiate(coinPrefab, whereToSpawn, Quaternion.identity);

        Collider createdCollider = createdObject.GetComponent<Collider>();
        Bounds createdBounds = createdCollider.bounds;

        bool skip = AABBCollisionTest(createdBounds);

        if (skip)
        {
            generatedBounds.Add(createdBounds);
            _coinAmount += 1;
        }
        else
            Destroy(createdObject);
    }

    bool AABBCollisionTest(Bounds newBounds)
    {
        foreach (Bounds existingBounds in generatedBounds)
            if (newBounds.Intersects(existingBounds))
                return false;
        return true;
    }

    void Update()
    {
        if (_coinAmount < 20)
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                GenerateObject();
            }
    }
}
