using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSentivity;

    private Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;

        //hiding cursor o screen

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate() 
    {
        // rotating player to mouse cursor direction

        float mouseX = Input.GetAxis("Mouse X") * mouseSentivity * Time.deltaTime;
        parent.Rotate(Vector3.up, mouseX);
    }
}
