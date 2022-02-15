using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position += movement * Time.deltaTime;
    }

    public void MoveLeft(InputAction.CallbackContext context) {
        if (context.started) {
            movement = new Vector3(-1, movement.y, movement.z);
        }
    }
    public void MoveRight(InputAction.CallbackContext context) {
        if (context.started) {
            movement = new Vector3(1, movement.y, movement.z);
        }
    }
    public void MoveUp(InputAction.CallbackContext context) {
        if (context.started) {
            movement = new Vector3(movement.x, 1, movement.z);
        }
    }
    public void MoveDown(InputAction.CallbackContext context) {
        if (context.started) {
            movement = new Vector3(movement.x, -1, movement.z);
        }
    }
}
