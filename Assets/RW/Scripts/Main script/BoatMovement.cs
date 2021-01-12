using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
	public Transform rameDroite;
	public Transform rameGauche;
	public float forward = 20.0f;
	public float friction = 0.99f;
	public float rotateAngle = 20.0f;
	public float actionTime = 1.0f;
    public float checkpointARamasser = 0;


	public bool pause = true;
	private bool rameDroiteLever = false;
	private bool rameGaucheLever = false;
	private float currentLeftActionTime=-3f;
	private float currentRightActionTime=-3f;
	private float lastFrictionTime = 0f;
	
	private CharacterController controller;
	private Vector3 moveVelocity = Vector3.zero;
	public GUI gui;


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
        if(checkpointARamasser<=0){
            pause = true;
            Debug.Log("Vous passez la ligne d'arrivée");
            gui.EcranDeFin();
        }
        else{
            Debug.Log("il vous manque des checkpoint pour finir la course");
        }
    }

    public void RamasserCheckpoint()
    {
        checkpointARamasser--;
    }
    // Update is called once per frame
    void Update()
    {
	    moveVelocity.x *= friction;
	    moveVelocity.z *= friction;
	    lastFrictionTime = Time.time;

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
                            moveVelocity += transform.TransformDirection(forward*Vector3.forward);
     					}
        			}
        			else{
        				if(Lhigh>Lelbow){
        					rameGaucheLever = true;
                            moveVelocity += transform.TransformDirection(forward*Vector3.forward);
        				}
        			}
        		}
        	}
        
            //input de la souris pour les personnes ne possedant pas de caméra 
            if(Input.GetButton("Fire1") && Time.time - currentLeftActionTime>actionTime){
            	currentLeftActionTime = Time.time;
                moveVelocity += transform.TransformDirection(forward*Vector3.forward);
            }
            if(Input.GetButton("Fire2") && Time.time - currentRightActionTime>actionTime){
            	currentRightActionTime = Time.time;
                moveVelocity += transform.TransformDirection(forward*Vector3.forward);
            }
            
            if(Time.time - currentLeftActionTime < actionTime){
	            // mettre (Time.time - currentLeftActionTime) dedans pour avoir un boost de vitesse qui réduit
	            moveVelocity += transform.TransformDirection(forward*0.1f*Vector3.forward);
	            transform.Rotate(Vector3.up, -rotateAngle*(Time.deltaTime/actionTime));
	            rameGauche.Rotate(Vector3.left, -360*(Time.deltaTime/actionTime));
            }

            if(Time.time - currentRightActionTime < actionTime){
	            // mettre (Time.time - currentLeftActionTime) dedans pour avoir un boost de vitesse qui réduit
	            moveVelocity += transform.TransformDirection(forward*0.1f*Vector3.forward);
	            transform.Rotate(Vector3.up, rotateAngle*(Time.deltaTime/actionTime));
	            rameDroite.Rotate(Vector3.left, -360*(Time.deltaTime/actionTime));
            }

            controller.Move(moveVelocity * Time.deltaTime);
        }
    }
}
