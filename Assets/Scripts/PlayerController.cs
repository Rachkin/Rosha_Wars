using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float mv_speed;
    public float mv_sh_k;
    public float cr_speed;

    private Rigidbody rb;
    private Transform tr;
    public Joystick joystick;
    private float last_time;
    private float now_time;
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    void Update ()
    {
        //if(Input.GetAxis("Horizontal");)
        now_time = Time.time;
        float dif = (now_time - last_time)*100;
        last_time = now_time;
        float lookY =  Input.GetAxis("Mouse X") * cr_speed;

       // rb.AddForce();

        Vector3 rot = new Vector3(0, lookY, 0);
        tr.Rotate(rot);
      //  Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);

     //   if (moveVector != Vector3.zero)
     //   {
     //       transform.rotation = Quaternion.LookRotation(moveVector);
     //       transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
     //   }
        //float Alfa;
        float moveX =
               (Input.GetAxis("Horizontal") /*+ joystick.Horizontal*/) * Mathf.Cos(Mathf.Deg2Rad * tr.rotation.eulerAngles.y)
              + Input.GetAxis("Vertical") * Mathf.Sin(Mathf.Deg2Rad * tr.rotation.eulerAngles.y);
        moveX = mv_speed * moveX * dif;

        // if(moveHorizontal == 0) moveHorizontal =  
        float moveZ = 
              (-Input.GetAxis("Horizontal") /*+ joystick.Horizontal*/) * Mathf.Sin(Mathf.Deg2Rad * tr.rotation.eulerAngles.y)
              + Input.GetAxis("Vertical") * Mathf.Cos(Mathf.Deg2Rad * tr.rotation.eulerAngles.y);
        moveZ = mv_speed * moveZ * dif;
        // = Input.GetAxis("Horizontal") * mv_speed * Mathf.Sin(tr.rotation.y * Mathf.PI) + Input.GetAxis("Vertical") * mv_speed * Mathf.Cos(tr.rotation.y * Mathf.PI);
        //     Debug.Log(tr.rotation.eulerAngles.y);
        //     Vector3 movement = new Vector3 (moveX + tr.position.x, 0.0f, moveZ + tr.position.z);

        if (Input.GetAxis("Shift") > 0.5)
        {
            moveX = moveX * mv_sh_k;
            moveZ = moveZ * mv_sh_k;
            Debug.Log(Input.GetAxis("Shift"));
        }
        Vector3 movement = new Vector3(moveX, 0.0f, moveZ);
        rb.velocity = movement;
   //     last_time = now_time;
    //    tr.position = movement;
    }
}