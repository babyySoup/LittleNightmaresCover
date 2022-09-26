using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    bool isOpen = false;
    Door doorcode;

    void OnTriggerEnter(Collider other)
    {
        if (isOpen == false)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("open door");
                doorcode.OpenDoor();
                isOpen = true;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        doorcode = GameObject.Find("Door").GetComponent<Door>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
