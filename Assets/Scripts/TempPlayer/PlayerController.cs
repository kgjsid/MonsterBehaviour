using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector3 moveDir;
    [SerializeField] float moveSpeed;
    [SerializeField] Transform playerTransform;

    private void Awake()
    {
        moveDir = Vector3.zero;
        moveSpeed = 3.0f;
        playerTransform = transform;
    }

    private void Update()
    {
        Move();
    }

    private void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();

        moveDir.x = inputDir.x;
        moveDir.y = inputDir.y;
    }

    private void Move()
    {
        playerTransform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
