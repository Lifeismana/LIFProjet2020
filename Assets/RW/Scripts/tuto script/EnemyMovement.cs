using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMovement : MonoBehaviour
{
	public float speed = 2.0f;
	public float rotationSpeed = 180.0f;
	public float gravity = 40.0f;

	private CharacterController controller;
	private Transform player;
	private float yVelocity = 0;
    // Start is called before the first frame update
    void Start()
    {
      controller = GetComponent<CharacterController>();
      player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
    	if(controller.isGrounded){
    		yVelocity = 0;
    		//Debug.Log("je suis grounded");
    	}
    	else{
    		yVelocity -= gravity * Time.deltaTime;
    	}
		Vector3 direction = player.position - transform.position;
   	direction.y = 0;
 
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
 
 		Vector3 Velocity = (transform.forward * speed) + (yVelocity * Vector3.up);
   	controller.Move(Velocity * Time.deltaTime);
    }
}
