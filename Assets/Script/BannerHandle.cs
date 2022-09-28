using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerHandle : MonoBehaviour
{
    bool isOpen = false;
    banner bannerCode;

    void OnTriggerEnter(Collider other)
    {
        if (isOpen == false)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("open hint");
                bannerCode.BannerUp();
                isOpen = true;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        bannerCode = GameObject.Find("Banner").GetComponent<banner>();

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
