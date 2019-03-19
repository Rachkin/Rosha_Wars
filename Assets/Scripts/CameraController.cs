using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed;
    private Transform tr;
    public float maxHeadRotation = 80.0f;
    public float minHeadRotation = -80.0f;
    private float currentHeadRotation = 0;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       // float lookX = -Input.GetAxis("Mouse Y") * cr_speed;
        //float newPos = (tr.rotation.eulerAngles.x + lookX + 90) % 360;
        //if (newPos >= 270) lookX = 270;
        //if (newPos <= 270 && newPos >= 180) lookX = 90;
        // if (tr.localRotation.x > 90) { tr.localRotation.x = 90; } else if (tr.localRotation.x < 0) { tr.localRotation.x = 0; }
        currentHeadRotation = Mathf.Clamp(currentHeadRotation + Input.GetAxis("Mouse Y") * rotationSpeed, minHeadRotation, maxHeadRotation);

        tr.localRotation = Quaternion.identity;
        tr.Rotate(Vector3.left, currentHeadRotation);

        Debug.Log(currentHeadRotation);
       // Vector3 rot = new Vector3(lookX, 0, 0);
       // tr.Rotate(rot);
        
    }
}
