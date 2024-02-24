# Player Movement

# Code
```cs
    [SerializeField] private float _speed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        transform.position += movement * _speed * Time.deltaTime;
    }
```
## The global variable that we see in Unity.
```cs
    [SerializeField] private float _speed = 5f;
```
## Control
Using the left arrow, right arrow, A and D. 
```cs
    float horizontal = Input.GetAxis("Horizontal");
```
Using the up arrow, down arrow, W and S.
```cs
    float vertical = Input.GetAxis("Vertical");
```

## Move
Add new values for X and Z to the newly created Vector3(x, y, z). I excluded Y since our player doesn't want to fly.
```cs
    Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
```
The player's position is changing when we use the move 
```cs
    transform.position += movement * _speed * Time.deltaTime;
```
