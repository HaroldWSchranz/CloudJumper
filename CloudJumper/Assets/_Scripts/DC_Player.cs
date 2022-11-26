using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DC_Player : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _gravity = 9.8f / 2f;
    [SerializeField]
    private float _jumpSpeed = 3.5f;
    [SerializeField]
    private float _doubleJumpMulitplier = 0.5f;

    private CharacterController _controller;

    private float _directionY;

    private bool _canDoubleJump = false;

    public float speed;

    public float rotationSpeed;



    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0);
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (_controller.isGrounded)
        {
            _canDoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                _directionY = _jumpSpeed;
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && _canDoubleJump)
            {
                _directionY = _jumpSpeed * _doubleJumpMulitplier;
                _canDoubleJump = false;
            }


        }


        _directionY -= _gravity * Time.deltaTime;

        direction.y = _directionY;

        _controller.Move(direction * _moveSpeed * Time.deltaTime);
    }
}
