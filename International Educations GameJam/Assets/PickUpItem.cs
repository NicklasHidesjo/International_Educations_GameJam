using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log(other.GetComponent<Item>().Type);

          

            FindObjectOfType<GamePlayManager>().ItemPickupTracker(other.GetComponent<Item>());

            other.gameObject.SetActive(false);
        }
    }

    

}
