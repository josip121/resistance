using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    Camera camera;
    private Rigidbody Rigidbody;
    public float speed = 50f;
    public float mouseSensetivity;
    public bool interactPressed=false;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();    
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        

    }

    void HandleInput()
    {
    }
    void FixedUpdate()
    {
        if (!interactPressed)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            //if (moveHorizontal != 0 || moveVertical != 0)
            //{
            //  Vector3 movment = new Vector3(moveHorizontal, 0.0f, moveVertical);
            // Rigidbody.AddForce(movment * speed);
            //}
            if (moveHorizontal != 0)

            {
                Rigidbody.AddForce(transform.right * speed * moveHorizontal);

            };

            if (moveVertical != 0)

            {
                Rigidbody.AddForce(transform.forward * speed * moveVertical);

            };

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            float rotAmountX = mouseX * mouseSensetivity * Time.deltaTime;
            float rotAmountY = mouseY * mouseSensetivity * Time.deltaTime;


            Vector3 cameraRotation = camera.transform.rotation.eulerAngles;
            cameraRotation.x -= rotAmountY;
            camera.transform.rotation = Quaternion.Euler(cameraRotation);

            Vector3 PlayerRotation = transform.rotation.eulerAngles;
            PlayerRotation.y += rotAmountX;

            transform.rotation = Quaternion.Euler(PlayerRotation);

        }
    }
       


}
