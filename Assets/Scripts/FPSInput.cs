using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]


public class FPSInput : MonoBehaviour
{
    public float speed = 6f;
    public float upSpeed = 10f;
    public CharacterController charController;
    public float gravity = -9.8f;
    public float jumpForce = 9.8f;
    public bool isOnGround=true;
    public float currentHeight;
    public Vector3 movement;
    public float flightCount=1f;
    //Vector3 jumpVector;
    //public Rigidbody rb;
    public bool jumped=false;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
        //jumpVector = new Vector3(0f, 200f, 0f);
    }

    void Update()
    {
        isOnGround = charController.isGrounded;
        if (!isOnGround)
            flightCount += Time.deltaTime * 7f;
        else
            flightCount = 1f;


        //speed = 6f;
        //if (Input.GetKey(KeyCode.LeftShift))
        //    speed = upSpeed;

        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");

        movement = new Vector3(deltaX, 0, deltaZ);
        movement = transform.TransformDirection(movement);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= speed;

        if (Input.GetKey(KeyCode.Space))
        {
            
            movement.y += jumpForce / flightCount;
            StartCoroutine(Jump());
        }

        movement.y += gravity*flightCount;
        charController.Move(movement*Time.deltaTime);
    }

    private IEnumerator Jump()
    {
        jumped = true;
        yield return new WaitForSeconds(1.3f);
        if (isOnGround)
        {
           
            jumped = false;
        }
        //flightCount = 1;
        //isOnGround = true;
        //movement.y += gravity*0.1f*;
        //charController.Move(movement);
    }
}

//public class FPSInput : MonoBehaviour
//{
//    public float speed = 6f;
//    public float upSpeed = 10f;
//    private CharacterController charController;
//    public float gravity = -9.8f;
//    public float jumpForce = 1.7f;
//    public bool isOnGround = true;

//    void Start()
//    {
//        charController = GetComponent<CharacterController>();
//    }

//    void Update() 
//    {
//        speed = 6f;

//        if (Input.GetKey(KeyCode.LeftShift))
//            speed = upSpeed;
//        float deltaX = Input.GetAxis("Horizontal") * speed;
//        float deltaZ = Input.GetAxis("Vertical") * speed;

//        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

//        movement = Vector3.ClampMagnitude(movement, speed);
//        //Ограничим движение по диагонали той же 
//        //скоростью, что и движение параллельно осям.



//        movement.y = gravity;
//        movement *= Time.deltaTime;

//        movement = transform.TransformDirection(movement);
//        //привязка вектора от локальных к глобальным коорд.

//        charController.Move(movement);


//    }
//}
