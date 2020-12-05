using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class lanceSilemi : MonoBehaviour
{
	public GameObject Silemi;
	public GameObject SilemiTropFort;
	public Transform SilemiBarrel;
	public float reloadTime = 0.5f;
	public int StrongFireAmo = 2;
	 
	private float lastFireTime;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(Mouse.current.leftButton.wasPressedThisFrame&&Time.time>lastFireTime + reloadTime){
			GameObject go = (GameObject)Instantiate(Silemi, SilemiBarrel.position, Quaternion.LookRotation(SilemiBarrel.forward));
    		Physics.IgnoreCollision(GetComponent<Collider>(), go.GetComponent<Collider>());
    		lastFireTime = Time.time;
		}
		if(Mouse.current.rightButton.wasPressedThisFrame&&Time.time>lastFireTime + reloadTime&&StrongFireAmo>0){
			GameObject go = (GameObject)Instantiate(SilemiTropFort, SilemiBarrel.position, Quaternion.LookRotation(SilemiBarrel.forward));
    		Physics.IgnoreCollision(GetComponent<Collider>(), go.GetComponent<Collider>());
    		lastFireTime = Time.time;
    		StrongFireAmo --;
		}
	}
}
