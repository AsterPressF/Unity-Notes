using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 m = new Vector3(horizontal, 0.0f, vertical);
        transform.position += m * speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        if (Time.time - lastJumpTime >= jumpCooldown)
            if (Input.GetKeyDown(jumpKey))
            {
                Jump();
            }
    }

    public float jumpForce = 4f;
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpCooldown = 0.9f;

    private Rigidbody rb;
    private float lastJumpTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.useGravity = false;
        }

        lastJumpTime = -jumpCooldown;
    }

    void Jump()
    {
        rb.useGravity = true;

        lastJumpTime = Time.time;
        
        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}