using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfDoor : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShelf()
    {
        animator.SetTrigger("shelfOpen");
    }

}
