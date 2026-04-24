using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionReference move;
    Rigidbody rb;
    public float speed;
    Vector2 moveDir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        moveDir = move.action.ReadValue<Vector2>();
        OnMove();
    }

    public void OnMove()
    {
        rb.linearVelocity = new Vector3(moveDir.x * speed,rb.linearVelocity.y, moveDir.y * speed);
    }
}
