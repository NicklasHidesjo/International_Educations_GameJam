using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{
    public Transform Flashlight;

    public float RotationSpeed;

    float AngleFlashlight;

    [Header("Min max rotation")]
    public float MaxRotation;

    public float MinRotation;

    private void Update()
    {
        RotateFlash();
    }

    void RotateFlash()
    {
        AngleFlashlight += Input.GetAxis("Mouse X") * RotationSpeed * -Time.deltaTime;
        AngleFlashlight = Mathf.Clamp(AngleFlashlight, MinRotation, MaxRotation);
        Flashlight.localRotation = Quaternion.AngleAxis(AngleFlashlight, Vector3.up);


    }






}
