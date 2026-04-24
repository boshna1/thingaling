using Unity.VisualScripting;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public enum Direction {Left, Right, Up, Down, D_UpLeft, D_UpRight, D_DownLeft, D_DownRight, Custom }
    public Direction dir;
    public float speed;
    Rigidbody rb;
    Vector2 customDireciton;
    Vector2 directionVector;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        switch (dir)
        {
            case Direction.Left:
                directionVector = Vector3.left;
                break;
            case Direction.Right:
                directionVector = Vector3.right;
                break;
            case Direction.Up:
                directionVector = Vector3.forward;
                break;
            case Direction.Down:
                directionVector = Vector3.down;
                break;
            case Direction.D_UpLeft:
                directionVector = Vector3.left + Vector3.forward;
                break;
            case Direction.D_UpRight:
                directionVector = Vector3.right + Vector3.forward;
                break;
            case Direction.D_DownLeft:
                directionVector = Vector3.left + Vector3.back;
                break;
            case Direction.D_DownRight:
                directionVector = Vector3.right + Vector3.back;
                break;
            case Direction.Custom:
                directionVector = customDireciton;
                break;
        }

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(new Vector3(directionVector.x * speed, rb.linearVelocity.y, directionVector.y * speed), ForceMode.Force);
    }
}
