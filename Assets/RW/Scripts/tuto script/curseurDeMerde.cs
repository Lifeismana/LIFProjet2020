using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class curseurDeMerde : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
    	if(Keyboard.current.escapeKey.wasPressedThisFrame){
      	if(Cursor.visible == true){
      		Cursor.lockState = CursorLockMode.Locked;
      		Cursor.visible = false;
      	}
      	else{
      		Cursor.lockState = CursorLockMode.None;
      		Cursor.visible = true;
      	}
    	}
    }
}
