using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    public Transform cam;
    //player control
    public float speed = 10f;
    public float mouseSensitivity = 1f;
    float xVal = 0f;
    float yVal = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void OnMove(InputValue inputValue)
    {
        Vector2 val = inputValue.Get<Vector2>();
        //Debug.Log("Came here " + val.x + " " + val.y);
        xVal = val.x;
        yVal = val.y;
        
    }
    void OnLook(InputValue inputValue)
    {
        Vector2 val = inputValue.Get<Vector2>();
        //Debug.Log(val.x + " "+ val.y);
        float yTmp = cam.rotation.eulerAngles.x - val.y*mouseSensitivity;
        if(yTmp>180){yTmp = yTmp-360f;}
        
        yTmp = Math.Clamp(yTmp, -90f, 90f);
        cam.localRotation = Quaternion.Euler(yTmp, 0, 0);
        transform.Rotate(new Vector3(0, val.x*mouseSensitivity,0));
    }
    void Update()
    {
        rb.linearVelocity = (transform.forward*yVal + transform.right*xVal)*speed + rb.linearVelocity.y*transform.up;
    }
}
