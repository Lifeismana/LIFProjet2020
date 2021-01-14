using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
	public Transform rameDroite;
	public Transform rameGauche;
	public float forward = 20.0f;
	public float friction = 0.99f;
    public float frictionTerrain = 0.2f;
	public float rotateAngle = 20.0f;
	public float actionTime = 1.0f;
    public float checkpointARamasser = 0f;


	public bool pause = true;
	private bool rameDroiteLever = false;
	private bool rameGaucheLever = false;
	private float currentLeftActionTime=-3f;
	private float currentRightActionTime=-3f;

	private CharacterController controller;
	private Vector3 moveVelocity = Vector3.zero;
	public GUI gui;

	private readonly quaternion defaultRotationValue = new quaternion(0f, 0f, 0f, 1f);
	
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
            friction = 0.991f;
        }
        else{
            Debug.Log("il vous manque des checkpoint pour finir la course");
        }
    }

    public void RamasserCheckpoint()
    {
        checkpointARamasser--;
    }

    void OnTriggerStay(Collider col){
        //quand on touche le terrain on est ralenti 
        if(col.gameObject.name == "Terrain"){
        		//Debug.Log("collision");
            moveVelocity.x *= frictionTerrain;
            moveVelocity.z *= frictionTerrain;

        }
    }
    // Update is called once per frame
    void Update()
    {
        // apllique la friction
	    moveVelocity.x *= friction;
	    moveVelocity.z *= friction;

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
	            // on continue à donner de la vitesse pendant l'animation
	            moveVelocity += transform.TransformDirection(forward*0.1f*Vector3.forward);
	            transform.Rotate(Vector3.up, -rotateAngle*(Time.deltaTime/actionTime));
	            rameGauche.Rotate(Vector3.left, -360*(Time.deltaTime/actionTime));
            }
            // On réinitialise la position de notre rame pcq on finit pas forcément notre rotation après 360°
            // TODO: C'est ptet mieux de fix le rotate plutôt que de faire ça  
            else
            {
	            // C'est ptet une mauvaise idée de faire ça à chaque update, j'ai pas test les conséquance sur les perfs 
	            // mais bon on est sur un ptit jeu ça doit pas avoir de conséquence et puis la seule idée que j'ai doit 
	            // clairement être plus gourmande que ça et pis si le compilo optimise pas ça, c'est qu'il est nul, nah!
	            // un peu un shitty fix pcq j'ai trouvé les valeurs en faisant un Debug.log()
	           rameGauche.localRotation = defaultRotationValue;
            }

            if(Time.time - currentRightActionTime < actionTime){
	            // on continue à donner de la vitesse pendant l'animation
	            moveVelocity += transform.TransformDirection(forward*0.1f*Vector3.forward);
	            transform.Rotate(Vector3.up, rotateAngle*(Time.deltaTime/actionTime));
	            rameDroite.Rotate(Vector3.left, -360*(Time.deltaTime/actionTime));
            }
            // On réinitialise la position de notre rame pcq on finit pas forcément notre rotation après 360°
            // TODO: C'est ptet mieux de fix le rotate plutôt que de faire ça  
            else
            {
	            // bis repetita d'au-dessus donc voir mon pavé cesar d'en-haut
	            // un peu un shitty fix pcq j'ai trouvé les valeurs en faisant un Debug.log()
	            rameDroite.localRotation = defaultRotationValue;
            }
            
        }
        controller.Move(moveVelocity * Time.deltaTime);
        if(!controller.isGrounded){
            controller.Move(-9*Vector3.up*Time.deltaTime);
        }
    }
}
