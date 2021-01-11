using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
	public CharacterController player;

    // Start is called before the first frame update
    void Start()
    {
      Physics.IgnoreCollision(player,GetComponent<Collider>());
    }

    void OnTriggerEnter(Collider col){
    	BoatMovement boat = col.gameObject.GetComponent<BoatMovement>();
    	if (boat != null){
    		boat.Terminer();
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
