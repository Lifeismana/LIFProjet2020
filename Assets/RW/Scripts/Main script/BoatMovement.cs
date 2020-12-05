using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
	public Transform rameDroite;
	public Transform rameGauche;
	public float forward = 10.0f;
	public float rotateAngle = 20.0f;
	public float actionTime = 1.0f;

	private float currentLeftActionTime=-3f;
	private float currentRightActionTime=-3f;
	private CharacterController controller;
	private bool rameDroiteLever = false;
	private bool rameGaucheLever = false;

    // Start is called before the first frame update
    void Start()
    {
      controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
    	//rame de droite avec openPose
    	if(GameObject.Find("4_RWrist")){
    		float Rhigh = GameObject.Find("4_RWrist").transform.position.y;
    		if(GameObject.Find("3_RElbow")){
    			float Relbow = GameObject.Find("3_RElbow").transform.position.y;
    			if(rameDroiteLever){
 					if(Rhigh<Relbow){
    					Debug.Log("je tourne a Droite");
 						currentRightActionTime = Time.time;
    					rameDroiteLever = false;
 					}
    			}
    			else{
    				if(Rhigh>Relbow){
    					rameDroiteLever = true;
    				}
    			}
    		}
    	}
    	//rame de gauche avec openPose
    	if(GameObject.Find("7_LWrist")){
    		float Lhigh = GameObject.Find("7_LWrist").transform.position.y;
    		if(GameObject.Find("6_LElbow")){
    			float Lelbow = GameObject.Find("6_LElbow").transform.position.y;
    			if(rameGaucheLever){
 					if(Lhigh<Lelbow){
    					Debug.Log("je tourne a gauche");
 						currentLeftActionTime = Time.time;
    					rameGaucheLever = false;
 					}
    			}
    			else{
    				if(Lhigh>Lelbow){
    					rameGaucheLever = true;
    				}
    			}
    		}
    	}

    	if(Input.GetButton("Fire1") && Time.time - currentLeftActionTime>actionTime){
    		Debug.Log("je tourne a gauche");
    		currentLeftActionTime = Time.time;
    	}
    	if(Input.GetButton("Fire2") && Time.time - currentRightActionTime>actionTime){
    		Debug.Log("je tourne a droite");
    		currentRightActionTime = Time.time;
    	}
    	Vector3 MoveVelocity = transform.TransformDirection(Vector3.forward*forward*Time.deltaTime);
    	if(Time.time - currentLeftActionTime < actionTime){
    		controller.Move(MoveVelocity);
    		transform.Rotate(Vector3.up, -rotateAngle*(Time.deltaTime/actionTime));
        rameGauche.Rotate(Vector3.left, -360*(Time.deltaTime/actionTime));
    	}
    	if(Time.time - currentRightActionTime < actionTime){
    		controller.Move(MoveVelocity);
    		transform.Rotate(Vector3.up, rotateAngle*(Time.deltaTime/actionTime));
        rameDroite.Rotate(Vector3.left, -360*(Time.deltaTime/actionTime));
    	}
    }
}
