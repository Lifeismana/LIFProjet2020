using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class capsule : MonoBehaviour
{
    private GameObject sphere;
    private Vector3 positionChangeCote;
    private Vector3 positionChangeRecul;
    private Vector3 positionChangeSaut;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("I am alive!");

        positionChangeCote = new Vector3(0.02f,0f,0f);
        positionChangeRecul = new Vector3(0f,0f,0.02f);
        positionChangeSaut = new Vector3(0f,0.02f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            transform.localPosition -= positionChangeRecul;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            transform.localPosition += positionChangeRecul;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            transform.localPosition += positionChangeCote;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            transform.localPosition -= positionChangeCote;
        }
        if (Keyboard.current.spaceKey.isPressed)
        {
        		transform.localPosition += positionChangeSaut;
        }
        else if(transform.localPosition.y>1)
        {
        		transform.localPosition -= positionChangeSaut;
        }
    }
}