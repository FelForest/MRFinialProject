using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonplayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        // Player Rigidbody
        private Rigidbody player;

        // player MoveVar
        public float walkingSpeed = 2.5f;
        private float speed;
        private Vector3 moveDir = Vector3.zero;
        private bool jumpRequest = false;

        // AnimatorVar
        private Animator animator;
        private bool isMoving = false;
        private bool isLanding = false;

        // Start is called before the first frame update
        void Start()
        {
            player = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();

            // Set speed
            speed = walkingSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            if (isLanding)
            {
                Move();
                Jump();
            }
            AnimationController();
        }

        private void FixedUpdate()
        {
            UpdatePosition();
        
        }
        void Move()
        {
            // Get KeyButtonInput
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            // Set player direction 
            moveDir = transform.forward * verticalInput + transform.right * horizontalInput;

            // Set isMoving
            isMoving = moveDir != Vector3.zero;
        }


        void UpdatePosition()
        {
            // Move the Player
            player.MovePosition(transform.position + moveDir.normalized * speed * Time.fixedDeltaTime);

            // Process jump request
            if (jumpRequest) 
            {
                jumpRequest = false;
                player.AddForce(Vector3.up * speed, ForceMode.Impulse);
            }
        }

        void Jump()
        {
            // Check for jump input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isLanding = false;
                jumpRequest = true;
            }
        }

        void AnimationController()
        {
            // Set animator parameters
            animator.SetBool("isMoving", isMoving);
            animator.SetBool("isLanding", isLanding);
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Check if player landed on the ground
            if (collision.collider.gameObject.CompareTag("Ground"))
            {
                isLanding = true;
            }
        }

        private void OnDisable()
        {
            isLanding = true;
            isMoving = false;
            AnimationController();
        }
    }

}