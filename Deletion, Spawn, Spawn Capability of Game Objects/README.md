# Spawn

# Code (First Class):
This code will connect to an empty object.
```cs
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
```

## Spawn Position and create
Vector3D took (X from -20 to 0, Y is 1, Z from -20 to 0).
```cs
    whereToSpawn = new Vector3(Random.Range(-20, 0), 1.0f, Random.Range(-20, 0));
``

Created the object
```cs
    createdObject = Instantiate(coinPrefab, whereToSpawn, Quaternion.identity);
```

## Check area and return result
Check if the area is free or not. 
```cs
    bool AABBCollisionTest(Bounds newBounds)
    {
        foreach (Bounds existingBounds in generatedBounds)
            if (newBounds.Intersects(existingBounds))
                return false;
        return true;
    }
```

If free => returns true, if occupied => returns false.
```cs
    bool skip = AABBCollisionTest(createdBounds);
```

## Fate of the object
Replenish List for future verification.
```cs
        if (skip)
        {
            generatedBounds.Add(createdBounds);
            _coinAmount += 1;
        }
        else
            Destroy(createdObject);
```

# Code (Second Class):
This code will be the connection to the created object.
```cs
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            CommunicationWithCoin._coinAmount -= 1;
        }
    }
```

## Trigger
If the tag of the object touched is "Player".
```cs
  if (other.CompareTag("Player"))
```
## Decrease
Decrease coins amount.
```cs
  CommunicationWithCoin._coinAmount -= 1;
```
