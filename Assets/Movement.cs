using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 60f;
    [SerializeField] private float jumpHeight = 10f;
    public Rigidbody2D PlayerRB;
    public bool isTouchingGround;
    private bool jumpRequested = false;
    float speedMX;
    bool btnPress;
    private float targetSpeed = 5f;

    public Transform groundCheck; 
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public LayerMask spikeLayer;
    public Transform startPos;

    private void Awake()
    {
        PlayerRB = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        float currentSpeed = targetSpeed * speedMX;

        PlayerRB.velocity = new Vector2(targetSpeed, PlayerRB.velocity.y);
    }

    public void Move(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            btnPress = true;
            speedMX = 1;
        }
        else if (value.canceled)
        {
            btnPress = false;
            speedMX = 0;
        }
    }
}
