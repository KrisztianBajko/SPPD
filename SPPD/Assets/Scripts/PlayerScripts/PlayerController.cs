using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Fields


    #endregion


    #region Private Fields
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 15f;

    [Header("Gravity / Jump")]
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float distanceToGround = .4f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckGameObject;
    private bool isGrounded;
    private Vector3 velocity;


    private CharacterController CC;
    

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!GameManager.Instance.isLevelFinished)
        {
            CalculateGravity();
            OnPlayerJump();
            OnPlayerMove();
        }
       
        
       
    }

    #endregion



    #region Public Methods


    #endregion


    #region Private Methods
    private void OnPlayerMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;


        CC.Move(move * moveSpeed * Time.deltaTime);
    }
    private void CalculateGravity()
    {

        isGrounded = Physics.CheckSphere(groundCheckGameObject.position, distanceToGround, groundLayer);


        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        velocity.y += gravity * Time.deltaTime;

        CC.Move(velocity * Time.deltaTime);
    }
    private void OnPlayerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    #endregion
}
