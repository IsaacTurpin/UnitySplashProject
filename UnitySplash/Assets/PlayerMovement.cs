using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sensitivityX = 1.0f;
    private float elapsedTime = 0;
    private bool noBackMov = true;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Turn");

        Rotating(turn);
        MovementManager(v);
    }
    void Rotating(float mouseXinput)
    {
        //access the avatar's rigidbody
        Rigidbody ourBody = this.GetComponent<Rigidbody>();

        //first check to see if we have rotation data that needs to be applied
        if (mouseXinput != 0)
        {
            //if so we use mouseX vaule to create a Euler angle which provides rotation in the Y axis
            //which is then turned to a Quaternion
            Quaternion deltaRotation = Quaternion.Euler(0f, mouseXinput * sensitivityX, 0f);

            // and then applied to turn the avatar via the rigidbody
            ourBody.MoveRotation(ourBody.rotation * deltaRotation);
        }
    }
    void MovementManager(float vertical)
    {

        transform.Translate(0, Input.GetAxis("Jump") * Time.deltaTime * speed, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        float v = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Turn");
    }
}