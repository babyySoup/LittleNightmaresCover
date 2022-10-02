using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTrigger : MonoBehaviour
{
    public Animator animator;
    bool isOpen = false;


    public GameObject shelfDoor;
    ShelfDoor sdCode;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        sdCode = shelfDoor.GetComponent<ShelfDoor>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (isOpen == false)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetTrigger("pulling");
                
                Debug.Log("open SD");
                sdCode.OpenShelf();
                isOpen = true;
            }
        }
    }


}
