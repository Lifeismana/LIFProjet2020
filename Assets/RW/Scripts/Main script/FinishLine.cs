using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col){
    	BoatMovement boat = col.gameObject.GetComponent<BoatMovement>();
    	if (boat != null){
    		boat.Terminer();
    		Debug.Log("Vous êtes arriver bravo");
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
