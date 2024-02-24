# Spawn

# Code
This code will be the connection to the created object
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
If an object with the tag "Player" touches this object.
```cs
  if (other.CompareTag("Player"))
```
## Decrease
Decrease coins amount
```cs
  CommunicationWithCoin._coinAmount -= 1;
```
