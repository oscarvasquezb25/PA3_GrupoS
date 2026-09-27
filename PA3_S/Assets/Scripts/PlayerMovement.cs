using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{    private CharacterController controller;
    public float speed = 5f;
    private Vector2 moveImput;
    public float gravity = -9.81f;
    private float verticalVelocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveImput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
        verticalVelocity += gravity * Time.deltaTime;

        Vector3 move = new Vector3(moveImput.x, 0, moveImput.y);
        //Vector3 velocity = new Vector3(move.x * speed, verticalVelocity, move.z * speed);
        Vector3 velocity = move * speed;
        velocity.y = verticalVelocity;

        //controller.Move(move * Time.deltaTime * speed);
        controller.Move(velocity * Time.deltaTime);
    }


}
