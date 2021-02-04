using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform player = null;
    [SerializeField] float offset = 10f;
    void Update()
    {
        float x = player.position.x;
        float y = transform.position.y;
        float z = player.position.z - offset;
        transform.position = new Vector3(x,y,z);
    }
}
