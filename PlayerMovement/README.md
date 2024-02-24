# Player Movement

## Control
Using the left arrow, right arrow, A and D. 
```cs
float horizontal = Input.GetAxis("Horizontal");
```
Using the up arrow, down arrow, W and S.
```cs
float vertical = Input.GetAxis("Vertical");
```

```cs
Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
```

```cs
transform.position += movement * _speed * Time.deltaTime;
```
