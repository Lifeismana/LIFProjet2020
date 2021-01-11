using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	public CharacterController player;
	public Material used;


	private bool ramasser = false;
    // Start is called before the first frame update
    void Start()
    {
      Physics.IgnoreCollision(player,GetComponent<Collider>());
    }

    void OnTriggerEnter(Collider col){
    	BoatMovement boat = col.gameObject.GetComponent<BoatMovement>();
    	if (boat != null){
    		if(!ramasser){
    			boat.RamasserCheckpoint();
    			Debug.Log("vous ramasser un checkpoint");
    			ramasser = true;
    			gameObject.transform.parent.GetComponent<MeshRenderer>().material = used;
    		}
    		else
    			Debug.Log("vous avez déjà ramasser ce checkpoint");
    	}
    }

    void Update()
    {
        
    }
}

