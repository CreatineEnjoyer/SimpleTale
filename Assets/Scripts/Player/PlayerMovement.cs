using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    
    private InputAction move;
    private PlayerControlActions playerAction;

    private SpriteRenderer sprite;
    private Vector2 movement = Vector2.zero;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sprite = this.GetComponent<SpriteRenderer>();
        playerAction = new PlayerControlActions();
    }

    private void FixedUpdate()
    {
        Moving();
    }

    private void Moving()
    {
        movement = move.ReadValue<Vector2>();
        Looking(move);
        rb.velocity += movement * speed * Time.fixedDeltaTime;
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }

    private void Looking(InputAction movement)
    {
        if(movement.ReadValue<Vector2>().x < 0f)
        {
            sprite.flipX = true;
        }
        else if(movement.ReadValue<Vector2>().x > 0f)
        {
            sprite.flipX = false;
        }
    }

    private void OnEnable()
    {
        move = playerAction.Player.Move;
        playerAction.Player.Enable();
    }

    private void OnDisable()
    {
        playerAction.Player.Disable();
    }
}
