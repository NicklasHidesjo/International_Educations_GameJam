using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRotateLight : MonoBehaviour
{

    Vector3 Campos;
    Camera Cam;



    void Start()
    {
        Cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition); RaycastHit hit; if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(hit.point); // Look at the point 
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
        }

    }

}