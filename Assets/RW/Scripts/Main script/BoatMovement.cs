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
    public float checkpointARamasser = 0;

	private float currentLeftActionTime=-3f;
	private float currentRightActionTime=-3f;
	private CharacterController controller;
	private bool rameDroiteLever = false;
	private bool rameGaucheLever = false;
    public bool pause = true;

    // Start is called before the first frame update
    void Start()
    {
      controller = GetComponent<CharacterController>();
    }


    public void Commencer()
    {
        pause = false;
    }

    public void Terminer()
    {
        pause = true;
    }

    public void RamasserCheckpoint()
    {
        checkpointARamasser--;
    }
    // Update is called once per frame
    void Update()
    {
    	if(!pause){
            //rame de droite avec openPose
        	if(GameObject.Find("4_RWrist")){
        		float Rhigh = GameObject.Find("4_RWrist").transform.position.y;
        		if(GameObject.Find("3_RElbow")){
        			float Relbow = GameObject.Find("3_RElbow").transform.position.y;
        			if(rameDroiteLever){
     					if(Rhigh<Relbow){
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
        
            //input de la souris pour les personnes ne possedant pas de caméra 
            if(Input.GetButton("Fire1") && Time.time - currentLeftActionTime>actionTime){
            	currentLeftActionTime = Time.time;
            }
            if(Input.GetButton("Fire2") && Time.time - currentRightActionTime>actionTime){
            	currentRightActionTime = Time.time;
            }
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
