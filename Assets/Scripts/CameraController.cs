using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float cr_speed;
    private Transform tr;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      //  float lookX = -Input.GetAxis("Mouse Y") * cr_speed;
       // if (tr.rotation.eulerAngles.x + lookX > 90 ) lookX = 0;
                                                    
       // Debug.Log(tr.rotation.eulerAngles);
       // Vector3 rot = new Vector3(lookX, 0, 0);
       // tr.Rotate(rot);
        
    }
}
