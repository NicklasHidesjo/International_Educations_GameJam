using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            FindObjectOfType<GamePlayManager>().ItemPickupTracker(other.GetComponent<Item>());
            other.gameObject.SetActive(false);
        }
    }
}
