using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banner : MonoBehaviour
{
    public Animator animator;

    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BannerUp()
    {
        animator.SetTrigger("goingUp");
    }
}
