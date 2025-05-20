using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    public float movementSpeed = 0.1f;
    private Rigidbody2D rb;
    private float x;
    private float y;

    private Vector2 input;
    public bool moving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();
        Animate();
    }

    private void FixedUpdate()
    {
        rb.velocity = input * movementSpeed;

    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        // Evita movimiento diagonal
        if (Mathf.Abs(x) > 0)
            y = 0;

        input = new Vector2(x, y);
        input = input.normalized;
    }


    /*

    // Movimiento en orden de prioridad según pulsación

    private Vector2 lastDirection = Vector2.zero;

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.W)) lastDirection = Vector2.up;
        if (Input.GetKeyDown(KeyCode.S)) lastDirection = Vector2.down;
        if (Input.GetKeyDown(KeyCode.A)) lastDirection = Vector2.left;
        if (Input.GetKeyDown(KeyCode.D)) lastDirection = Vector2.right;

        // Movimiento continuo mientras la tecla está siendo presionada
        bool holdingHorizontal = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        bool holdingVertical = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);

        // Solo permitir movimiento en el último eje presionado si se sigue manteniendo
        if (lastDirection == Vector2.left && Input.GetKey(KeyCode.A))
            input = Vector2.left;
        else if (lastDirection == Vector2.right && Input.GetKey(KeyCode.D))
            input = Vector2.right;
        else if (lastDirection == Vector2.up && Input.GetKey(KeyCode.W))
            input = Vector2.up;
        else if (lastDirection == Vector2.down && Input.GetKey(KeyCode.S))
            input = Vector2.down;
        else
            input = Vector2.zero;
    }

    */


    private void Animate()
    {
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving)
        {
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
        }

        animator.SetBool("Moving", moving);
    }
}
