# Spawn

# Code:
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
If the tag of the object touched is "Player".
```cs
  if (other.CompareTag("Player"))
```
## Decrease
Decrease coins amount
```cs
  CommunicationWithCoin._coinAmount -= 1;
```
