﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//

public class playermovement : MonoBehaviour// NetworkBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public float RotateSpeed = 30f;
  //  public Vector3 spawnpoint;

    public Image Map;
    public GameObject howto;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
 //   float rotationX = 0;

    

    [HideInInspector]
    public bool canMove = true;

  void Start()
    {
      //  if (!hasAuthority)
         //   Destroy(this);
        characterController = GetComponent<CharacterController>();
        //  spawnpoint = transform.position;
        //   characterController.enabled= true;
        //    playerCamera.enabled = true;
        Map = GameObject.FindGameObjectWithTag("map1").GetComponent<Image>(); 
       
    }
   
  //  public override void OnStartAuthority()
  //  {
   //     base.OnStartAuthority();
   // }

    void Update()
    {
      //  if (!hasAuthority) return;
       
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
            howto.SetActive(false);
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
     
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.C))
            Map.enabled=true;
        if (Input.GetKeyUp(KeyCode.C))
            Map.enabled=false;

        // Player and Camera rotation
        //  if (canMove)
        // {
        //     rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        //     rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        //    playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        //   transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        // }

}
  
}