using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cube : MonoBehaviour
{
    private GameObject sphere;
    private Vector3 scaleChange;
    private Vector3 positionChange;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("I am alive!");

        scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
        positionChange = new Vector3(0.02f,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            transform.localScale += scaleChange;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            transform.localScale -= scaleChange;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            transform.localPosition += positionChange;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            transform.localPosition -= positionChange;
        }
    }
}
