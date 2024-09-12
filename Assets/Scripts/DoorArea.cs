using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorArea : MonoBehaviour
{
    public UnityAction playerEntered;
    public UnityAction playerExited;
    private void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            playerEntered.Invoke();
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == 6)
        {
            playerExited.Invoke();
        }
    }
}
