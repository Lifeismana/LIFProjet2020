using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 10.0f;
	public float sprintSpeed = 15.0f;
	public float rotationSpeed = 2.0f;
	public Transform head;
	public float maxHeadRotation = 70.0f;
	public float minHeadRotation = -70.0f;
	public float jumpSpeed = 10.0f;
	public float gravity = 40.0f;
	public float MouseSensibility = 10.0f;

	private float currentHeadRotation = 0;
	private float yVelocity = 0;
	private CharacterController controller;
	private Vector3 moveVelocity = Vector3.zero;
   // Start is called before the first frame update
   void Start()
   {
      controller = GetComponent<CharacterController>();
   }

   // Update is called once per frame
   void Update()
   {
    	float s = speed;
    	

    	if (controller.isGrounded)
		{
	    	Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

	    	if (Keyboard.current.shiftKey.isPressed){
	    		s = sprintSpeed;
	    	}
	    	moveVelocity = transform.TransformDirection(input * s);

	      yVelocity = 0;
	      if (Keyboard.current.spaceKey.isPressed){
	       	yVelocity = jumpSpeed;
	      }
   	}
    	else{
      	yVelocity -= gravity * Time.deltaTime;
    	}
    	Vector3 Velocity = moveVelocity + yVelocity * Vector3.up;
    	controller.Move(Velocity * Time.deltaTime);

    	Vector2 mouseInput = Mouse.current.delta.ReadValue()*(MouseSensibility/100.0f);

		transform.Rotate(Vector3.up, mouseInput.x * rotationSpeed);

		currentHeadRotation = Mathf.Clamp(currentHeadRotation + mouseInput.y * rotationSpeed, minHeadRotation, maxHeadRotation);
  
		head.localRotation = Quaternion.identity;
		head.Rotate(Vector3.left, currentHeadRotation);
	}

}
